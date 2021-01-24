    public class NewTest
    {
        IEnumerable<dynamic> cachedDirectory;
        public IEnumerable<dynamic> GetData()
        {
             var request = new RestRequest();
            var directoryResponse = client.ExecuteTaskAsync(request).Result;
            dynamic directory = JsonConvert.DeserializeObject<IEumerable<MyDTO>>(directoryResponse.Content);            
            return directory;            
        }
    }
    public class MyDTO
    {
        public string Name { get; set; }
    }
