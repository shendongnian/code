                BlobContinuationToken continuationToken = null;
                var resultSegment=cloudBlobContainer.ListBlobsSegmentedAsync("", true, BlobListingDetails.All, 100, continuationToken, null, null).Result;
                foreach (IListBlobItem item in resultSegment.Results)
                {
                    #need a type conversion here
                    var temp = item as CloudBlockBlob;
                    
                    #this line of code is needed for fetch attribute and metadata.
                    temp.FetchAttributes();
                    Console.WriteLine("URL: {0}", temp.StorageUri.PrimaryUri.ToString());
                    Console.WriteLine("Creation time: {0}", temp.Properties.Created.ToString());
                }
