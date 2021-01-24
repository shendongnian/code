        var client = new AmazonCloudFrontClient();        
                client.UpdateDistribution(new UpdateDistributionRequest
                {
                    Id = "YOURDISTID",
                    DistributionConfig = new DistributionConfig
                    {
                        WebACLId = "",
                        HttpVersion = "http2",
                        IsIPV6Enabled = true,
                        DefaultRootObject = "maintenance.html",
                        CacheBehaviors = new CacheBehaviors {
                            Quantity = 0,                            
                        },
                        Restrictions = new Restrictions {
                            GeoRestriction = new GeoRestriction
                            {
                                Quantity = 0,
                                RestrictionType = "none"
                            }
                        },
                        CustomErrorResponses = new CustomErrorResponses {
                            Quantity = 0                            
                        },                     
                        ViewerCertificate = new ViewerCertificate {
                            SSLSupportMethod = "sni-only",
                            ACMCertificateArn = "YOUR_IMPORTED_CERT_ARN",
                            MinimumProtocolVersion = "TLSv1.1_2016"                           
                        },
                        Enabled = true,
                        Comment = "Maintenance",
                        Origins = new Origins
                        {
                            Items = new List<Origin>() {
                                new Origin(){Id = "S3-example.example.com", DomainName = "example.example.com.s3.amazonaws.com", S3OriginConfig = new S3OriginConfig(){ OriginAccessIdentity = "" }, OriginPath = "", CustomHeaders = new CustomHeaders{ Quantity = 0 } }
                            },
                            Quantity = 1                           
                        },
                        Logging = new Amazon.CloudFront.Model.LoggingConfig
                        {
                            Bucket = "example.example.com.s3.amazonaws.com",
                            IncludeCookies = false,
                            Enabled = false,
                            Prefix = ""
                        },
                        PriceClass = "PriceClass_All",
                        Aliases = new Aliases
                        {                         
                            Quantity = 1,
                            Items = list
                        },
                        CallerReference = cf,
                        DefaultCacheBehavior = new DefaultCacheBehavior
                        {
                           ForwardedValues = new ForwardedValues
                           {
                               QueryString = false,
                               QueryStringCacheKeys = new QueryStringCacheKeys {
                                   Quantity = 0
                               },
                               Headers = new Headers {
                                   Quantity = 0                                  
                               },
                               Cookies = new CookiePreference
                               {
                                   Forward = "none"                                   
                               }
                           },
                           AllowedMethods = new AllowedMethods {
                               Quantity = 2,
                               Items = httpmeth,
                               CachedMethods = new CachedMethods
                               {
                                   Quantity = 2,
                                   Items = httpmeth
                               }
                           },
                           DefaultTTL = 86400,
                           Compress = false,
                           MaxTTL = 31536000,
                           TargetOriginId = "S3-example.example.com",
                            LambdaFunctionAssociations = new LambdaFunctionAssociations {
                               Quantity = 0
                           },                          
                           ViewerProtocolPolicy = "allow-all", 
                           MinTTL = 0,
                           SmoothStreaming = false,
                           TrustedSigners = new TrustedSigners
                           {
                               Enabled = false,
                               Quantity = 0,                                                            
                           },               
                        }
                    },
                    IfMatch = tag
                });
                client.Dispose();
