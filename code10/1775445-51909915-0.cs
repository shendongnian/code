    class Program
    {
        static void Main(string[] args)
        {
            string jsonPath = @"c:\debug\data.json";
            System.IO.Stream s = new System.IO.FileStream(jsonPath,System.IO.FileMode.Open, System.IO.FileAccess.Read);
            
            AppIds data = JsonConvert.DeserializeObject<Dictionary<string, AppIds>>(File.ReadAllText(jsonPath))["apps"];
        }
    }
