    class Program
    {
        static void Main(string[] args)
        {
            var json = @"{'repoData':[{'name':'Example','displayName':'Example1','type':'git','enabled':true,'available':true,'location':'Example.com','path':''}, {'name':'Example','displayName':'Example2','type':'git','enabled':true,'available':true,'location':'Example.com','path':''}]}";
    
            RootObject4 rootObject4 = JsonConvert.DeserializeObject<RootObject4>(json);
    
            List<string> displayNames = new List<string>();
    
            foreach (var item in rootObject4.repoData)
            {
                displayNames.Add(item.displayName);
            }
    
            displayNames.ForEach(x => Console.WriteLine(x));
    
            Console.ReadLine();
        }
    }
    
