    static void Main(string[] args)
            {
                string data = File.ReadAllText("D://readjson.txt");
                dynamic datavales = JsonConvert.DeserializeObject(data);
    
                dynamic keydata = datavales.myObj2;
                foreach(dynamic obj2values in keydata)
                {
                   //obj2values contain all the values access it using obj2values object
                   Console.WriteLine( obj2values.name);
                }
    
            }
