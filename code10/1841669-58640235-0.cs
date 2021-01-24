            var result = new List<string>();
            var directory = _blobContainer.GetDirectoryReference(relativeFilePath);
            if (directory.Equals(null))
                return result;
            var blobs = directory.ListBlobsSegmentedAsync(null).Result;
            foreach (var item in blobs.Results)
            {
                if (item.GetType() == typeof(CloudBlobDirectory)) 
                {
                    result.Add(item.Uri.Segments.Last().Trim('/'));
                }
            }
            return result;
