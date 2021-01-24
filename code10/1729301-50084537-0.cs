        public class NewTest
        {
            IEnumerable<dynamic> cachedDirectory;
            public IEnumerable<dynamic> GetData()
            {
                dynamic directory = JsonConvert.DeserializeObject<MyDTO>("{ 'Name' : 'Test'  }");
                cachedDirectory = directory;
                return cachedDirectory;            
            }
        }
    
        public class MyDTO
        {
            public string Name { get; set; }
        }
