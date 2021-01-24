        [HttpPost]
        [Route("api/forge/oss/buckets/delete")]
        public async Task<dynamic> DeleteBucket([FromBody]CreateBucketModel bucket)
        {
            BucketsApi buckets = new BucketsApi();
            dynamic token = await OAuthController.GetInternalAsync();
            buckets.Configuration.AccessToken = token.access_token; 
            await buckets.DeleteBucketAsync(bucket.bucketKey); 
            //or
            //buckets.DeleteBucket(bucket.bucketKey); 
            return Task.CompletedTask;
        }
        [HttpPost]
        [Route("api/forge/oss/objects/delete")]
        public async Task<dynamic> DeleteObject([FromBody]DeleteObjectModel 
                                                          objInfo)
        {
            ObjectsApi objs = new ObjectsApi();
            dynamic token = await OAuthController.GetInternalAsync();
            objs.Configuration.AccessToken = token.access_token;
            
            await objs.DeleteObjectAsync(objInfo.bucketKey, objInfo.objectKey);
            //or
            //objs.DeleteObject(objInfo.bucketKey, objInfo.objectKey); 
            return Task.CompletedTask;
        }
        public class CreateBucketModel
        {
          public string bucketKey { get; set; }
        }
        public class DeleteObjectModel
        {
           public string bucketKey { get; set; }
           public string objectKey { get; set; } 
         }
