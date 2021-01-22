    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class RemoveExample
    {
        public List<Item> RemoveAddresses(List<Item> sourceList, List<string> emailAddressesToRemove)
        {
            List<Item> newList = (from s in sourceList
                                  where !emailAddressesToRemove.Contains(s.Email)
                                  select s).ToList();
            return newList;
        }
    
        public class Item
        {
            public string Email { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
        }
    }
