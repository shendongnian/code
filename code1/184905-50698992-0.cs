      public async Task<bool> ObjectExistsAsync(string prefix)
      {
         var response = await _amazonS3.GetAllObjectKeysAsync(_awsS3Configuration.BucketName, prefix, null);
         return response.Count > 0;
      }
