    class Program
    {
        static void Main(string[] args)
        {
            //This is your sample json that comes from Rest API
            string json = @"
                            {'enrollment_fields':{  
                                                 '4':'ABC123',
                                                 '5': 'XYZ123',
                                                 '6': 'PQR123'
                                                 }
                            }";
    
    
            //Deserialize your json into Dictionary of dictionary.
            var obj = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
    
            //Get your desired key from outer dictionary
            var enrollment_fields = obj["enrollment_fields"];
    
            //Loop on inner dictionary key to get values
            foreach (string key in enrollment_fields.Keys)
                //Here you get your dynamic key. e.g. 4,5,6
                Console.WriteLine(key + ": " + enrollment_fields[key]);
    
            Console.ReadLine();
        }
    }
    
