        public List<string> GetData()
        {
         if(Cache[key] == null)
        {
           lock(obj) // obj should be static
           {
                if(Cache[key] == null)
                {
                    // Load data from service
                    Cache[key] == data;
                }
            }
         }
         return (List<string>)Cache[Key]; 
         }
