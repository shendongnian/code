        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            [WebInvoke(Method ="POST",RequestFormat =WebMessageFormat.Json,ResponseFormat =WebMessageFormat.Json)]
            Task UploadStream(Stream stream);
    
        }
        public class Service1 : IService1
        {
            public async Task UploadStream(Stream stream)
            {
                using (stream)
                {
                    //save file to local folder
                    using (var file=File.Create(@"C:\"+Guid.NewGuid().ToString()+".png"))
                    {
                        await stream.CopyToAsync(file);
                    }
                }
            }
    }
