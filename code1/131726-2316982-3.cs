            System.Collections.Specialized.NameValueCollection no = new System.Collections.Specialized.NameValueCollection();
            no.Add("d", "4");
            no.Add("b", "1");
            no.Add("a", "2");
            no.Add("c", "3");
            var nvc = no.ToPairs();
            // To order the items based on key in descending order
            var orderedbykey=nvc.OrderByDescending(x => x.Key).ToList();  
           // To order the items based on value in descending order           
           var orderedbyval=nvc.OrderByDescending(x => x.Value).ToList();
           //or order by ur custom enum key
           var orderbyEnumKey  = nvc.OrderBy(x => x.Key == "urenumkey").ToList();
