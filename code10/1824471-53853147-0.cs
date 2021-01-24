    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    
    namespace Aws
    {
        public static class CacheInvalidationRequestBuilder
        {
            private const string ServiceName    = "execute-api";
            private const string Algorithm      = "AWS4-HMAC-SHA256";
            private const string ContentType    = "application/json";
            private const string DateTimeFormat = "yyyyMMddTHHmmssZ";
            private const string DateFormat     = "yyyyMMdd";
    
            public static WebRequest Build(CacheInvalidationRequestModel request)
            {
                string hashedRequestPayload = CreateRequestPayload(String.Empty);
    
                string authorization = Sign(request, hashedRequestPayload, "GET", request.AbsolutePath, request.QueryString);
                string requestDate = DateTime.UtcNow.ToString(DateTimeFormat);
    
                var webRequest = WebRequest.Create($"https://{request.Host}{request.AbsolutePath}");
    
                webRequest.Method = "GET";
                webRequest.ContentType = ContentType;
     
                webRequest.Headers.Add("Cache-Control", "max-age=0");
                webRequest.Headers.Add("Host", request.Host);
                webRequest.Headers.Add("X-Amz-Date", requestDate);
    
                webRequest.Headers.Add("Authorization", authorization);
    
                return webRequest;
            }
    
            private static string CreateRequestPayload(string jsonString)
            {
                return HexEncode(Hash(ToBytes(jsonString)));
            }
    
            private static string Sign(CacheInvalidationRequestModel request, string hashedRequestPayload, string requestMethod, string canonicalUri, string canonicalQueryString)
            {
                var currentDateTime = DateTime.UtcNow;
    
                var dateStamp = currentDateTime.ToString(DateFormat);
                var requestDate = currentDateTime.ToString(DateTimeFormat);
                var credentialScope = $"{dateStamp}/{request.Region}/{ServiceName}/aws4_request";
    
                var headers = new SortedDictionary<string, string> {
                    { "cache-control", "max-age=0" },
                    { "content-type", ContentType },
                    { "host", request.Host },
                    { "x-amz-date", requestDate }
                };
    
                var canonicalHeaders = string.Join("\n", headers.Select(x => x.Key.ToLowerInvariant() + ":" + x.Value.Trim())) + "\n";
    
                // Task 1: Create a Canonical Request For Signature Version 4
                var SignedHeaders = String.Join(';', headers.Select(x => x.Key.ToLowerInvariant()));
    
                var canonicalRequest = $"{requestMethod}\n{canonicalUri}\n{canonicalQueryString}\n{canonicalHeaders}\n{SignedHeaders}\n{hashedRequestPayload}";
    
                var hashedCanonicalRequest = HexEncode(Hash(ToBytes(canonicalRequest)));
    
                // Task 2: Create a String to Sign for Signature Version 4
                var stringToSign = $"{Algorithm}\n{requestDate}\n{credentialScope}\n{hashedCanonicalRequest}";
    
                // Task 3: Calculate the AWS Signature Version 4
                var signingKey = GetSignatureKey(request.SecretKey, dateStamp, request.Region, ServiceName);
                var signature = HexEncode(HmacSha256(stringToSign, signingKey));
    
                // Task 4: Prepare a signed request
                // Authorization: algorithm Credential=access key ID/credential scope, SignedHeadaers=SignedHeaders, Signature=signature
                var authorization = $"{Algorithm} Credential={request.AccessKey}/{dateStamp}/{request.Region}/{ServiceName}/aws4_request, SignedHeaders={SignedHeaders}, Signature={signature}";
    
                return authorization;
            }
    
            private static byte[] GetSignatureKey(string key, string dateStamp, string regionName, string serviceName)
            {
                var kDate = HmacSha256(dateStamp, ToBytes("AWS4" + key));
                var kRegion = HmacSha256(regionName, kDate);
                var kService = HmacSha256(serviceName, kRegion);
                return HmacSha256("aws4_request", kService);
            }
    
            private static byte[] ToBytes(string str)
            {
                return Encoding.UTF8.GetBytes(str.ToCharArray());
            }
    
            private static string HexEncode(byte[] bytes)
            {
                return BitConverter.ToString(bytes).Replace("-", string.Empty).ToLowerInvariant();
            }
    
            private static byte[] Hash(byte[] bytes)
            {
                return SHA256.Create().ComputeHash(bytes);
            }
    
            private static byte[] HmacSha256(string data, byte[] key)
            {
                return new HMACSHA256(key).ComputeHash(ToBytes(data));
            }
        }
    }
