    /// <summary>
    /// Determines whether a file exists within the specified bucket
    /// </summary>
    /// <param name="bucket">The name of the bucket to search</param>
    /// <param name="filePrefix">Match files that begin with this prefix</param>
    /// <returns>True if the file exists</returns>
    public async Task<bool> FileExists(string bucket, string filePrefix)
    {
        // Set this to your S3 region (of course)
        var region = Amazon.RegionEndpoint.USEast1;
        using (var client = new AmazonS3Client(region))
        {
            var request = new ListObjectsRequest {
                BucketName = bucket,
                Prefix = filePrefix,
                MaxKeys = 1
            };
    
            var response = await client.ListObjectsAsync(request, CancellationToken.None);
    
            return response.S3Objects.Any();
        }
    }
