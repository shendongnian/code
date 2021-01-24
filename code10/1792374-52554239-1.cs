    class Program
    {
        static void Main(string[] args)
        {
            string inputJson = @"{'amounts':[{'tid':7072,'amount':10000,'currency':'USD'},{'tid':7072,'amount':4000,'currency':'USD'}],'status':0,'errorCode':0}";
    
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(inputJson);
    
            foreach (var item in rootObject.amounts)
            {
                item.amount = item.amount / 10;
            }
    
            //OR you can do it with shorter version of foreach
            //rootObject.amounts.ForEach(x => x.amount = x.amount / 10);
    
            string outputJson = JsonConvert.SerializeObject(rootObject);
    
            Console.WriteLine(outputJson);
            Console.ReadLine();
        }
    }
