    using System.Collections.Generic;
    using System.Linq;
    
    namespace Demo
    { 
        public class Test
        {
            public void SortTest()
            {
                var myList = new List<Item> { new Item { Name = "Test", Id = 1 }, new Item { Name = "Other", Id = 1 } };
                var result = myList.OrderBy(x => x.Name);
            }
        }
    
        public class Item
        {
            public string Name { get; set; }
            public int Id { get; set; }
        }
    }
