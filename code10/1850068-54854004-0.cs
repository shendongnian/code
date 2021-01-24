    public class STORE
        {
            public string TITLE { get; set; }
            public string TITLE1 { get; set; }
            public string TITLE2 { get; set; }
        }
    
        public class PROJECT
        {
            public STORE STORE { get; set; }
        }
    
        public class RootObject
        {
            public PROJECT PROJECT { get; set; }
        }
    
        public class Program
        {
    
            public void GetValues()
            {
    
                WebClient client = new WebClient();
    
                string reply =
                    client.DownloadString("https://api.myjson.com/bins/ftu3a");
                reply = reply.Replace("11", "STORE");
    
                var stuff = JsonConvert.DeserializeObject<List<RootObject>>(reply);
    
    
                foreach (var item in stuff)
                {
                    Console.WriteLine(item); Console.Read();
                }
    
            }
            public static void Main()
            {
                Program P1 = new Program();
                P1.GetValues();
            }
        }
