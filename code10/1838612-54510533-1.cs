    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Google.Cloud.Storage.V1;
    using System.IO;
    using System.Net.Http;
    using Google.Apis.Auth.OAuth2;
    namespace stackoverflow54387198
    {
        class Program
        {
            static void Main(string[] args)
            {
                // step 1 create customer encryption key
                var key = EncryptionKey.Generate().Base64Key;
                var encryptionKey = EncryptionKey.Create(Convert.FromBase64String(key));
                // step 2 get you service Acount cert for auth
                string serviceAcountCert = "stackoverflow54387198-xxxxxxxx.json";
                // step 3 get you service Acount cert for auth
                string bucketName = "stackoverflow_54387198_bucket";
                string localPath = "FileToUpload.txt";
                string objectName = null;
                // step 4 create a local text file to upload
                File.WriteAllText(localPath, "test");
                // step 5 Create Google Storage Client
                var storage = StorageClient.Create(
                    GoogleCredential.FromJson(File.ReadAllText(serviceAcountCert)));
                // step 6 upload the file with the customer encryption key from step 1
                using (var f = File.OpenRead(localPath))
                {
                    objectName = objectName ?? Path.GetFileName(localPath);
                    storage.UploadObject(bucketName, objectName, null, f,
                        new UploadObjectOptions()
                        {
                            EncryptionKey = encryptionKey
                        });
                    Console.WriteLine($"Uploaded {objectName}.");
                }
                // step 7 create a url
                // step 7.1 create add x-goog-encryption-algorithm hear 
                //to tell google you are using  customer encryption key
                var requestHeaders = new Dictionary<string, IEnumerable<string>>
                {
                    {
                        "x-goog-encryption-algorithm", new [] { "AES256" }
                    }
                };
                // step 7.2  set other parameters
                var expireAfter = TimeSpan.FromHours(30.0);
                var verb = HttpMethod.Get;
                // step 7.3  create a Url Signer
                var urlSigner = UrlSigner.FromServiceAccountPath(serviceAcountCert);
                // step 7.4  create a secure url
                var url = urlSigner.Sign(
                            bucketName,
                            objectName,
                            expireAfter,
                            verb,
                            requestHeaders);
                // step 8  use the Your Url
                // step 8.1 create HttpClient
                var client = new HttpClient();
                // step 8.1  add x-goog-encryption-algorithm header the same from step 7
                client.DefaultRequestHeaders.Add("x-goog-encryption-algorithm", "AES256");
                // step 8.2  add x-goog-encryption-key header with customer encryption key (Base64Hash)
                client.DefaultRequestHeaders.Add("x-goog-encryption-key", encryptionKey.Base64Key);
                // step 8.3  add x-goog-encryption-key header with customer encryption key (Base64Hash)
                client.DefaultRequestHeaders.Add("x-goog-encryption-key-sha256", encryptionKey.Base64Hash);
                // step 8.4  Download the file 
                Task.Run(async () =>
                {
                    var response = await client.GetAsync(url);
                    var contents = await response.Content.ReadAsStringAsync();
                    // contents == "test"
                    Console.WriteLine($"contents=>{contents}");
                }).GetAwaiter().GetResult();
                Console.ReadLine();
            }
        }
    }
