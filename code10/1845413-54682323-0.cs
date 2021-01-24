                BlobContinuationToken continuationToken = null;
                var resultSegment=cloudBlobContainer.ListBlobsSegmentedAsync("", true, BlobListingDetails.All, 100, continuationToken, null, null).Result;
                foreach (IListBlobItem item in resultSegment.Results)
                {
                    var temp = item as CloudBlockBlob;
                    temp.FetchAttributes();
                    Console.WriteLine("URL: {0}", temp.StorageUri.PrimaryUri.ToString());
                    Console.WriteLine("Creation time: {0}", temp.Properties.Created.ToString());
                }
