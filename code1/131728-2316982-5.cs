            System.Collections.Specialized.NameValueCollection col1= new System.Collections.Specialized.NameValueCollection();
            col1.Add("key1", "value1");
            col1.Add("key-x", "value2");
            col1.Add("key-y", "value3");
            col1.Add("key9", "value4");
            col1.Add("key3", "value5");
            col1.Add("key5", "value6");
            col1.Add("key-z", "value7"); 
            var nvc = col1.ToPairs();
            // To order the items based on key in descending order
            var orderedbykey=nvc.OrderByDescending(x => x.Key).ToList();  
           // To order the items based on value in descending order           
           var orderedbyval=nvc.OrderByDescending(x => x.Value).ToList();
           //or order by ur custom enum key
            var orderbyEnumKeys = colc.OrderBy(x =>
            {
                int en;
                try
                {
                     en = (int)Enum.Parse(typeof(OrderEnum), x.Key);
                }
                catch (Exception ex)
                {
                    return int.MaxValue;
                }
                return en;
            }).ToList();
