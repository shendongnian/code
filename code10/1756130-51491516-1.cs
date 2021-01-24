    public string GetExistingProducts()
            {
                var x = yourservice.function().toList();
                string a = string.Empty;
                foreach (var item in x)
                {
                    a += item + ",";
                }
    
                return a;
               
    
            }
