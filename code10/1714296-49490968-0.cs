        var client2 = new AmazonCloudFrontClient();
                var tag = client2.GetDistributionConfig(new GetDistributionConfigRequest
                {
                    Id = "YOURDISTID"
                }).ETag;
                string cf = client2.GetDistributionConfig(new GetDistributionConfigRequest
                {
                    Id = "YOURDISTID"
                }).DistributionConfig.CallerReference;
                client2.Dispose();
