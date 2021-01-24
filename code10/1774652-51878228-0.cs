    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        public class Program
        {
            public static void Main()
            {
                Item item = new Item();
                item.CreateList();
                Item.Recursive(0, new List<string>());
                foreach(string descendant in Item.descendants)
                {
                    Console.WriteLine(descendant);
                }
                Console.ReadLine();
     
            }
        }
        public class Item
        {
            public static List<string> descendants = new List<string>();
            public static List<Item> items = null;
            public int Id { get; set; }
            public string Name { get; set; }
            public int ParentId { get; set; }
            public void CreateList()
            {
                items = new List<Item>() {
                   new Item { Id = 1, Name = "Parent1", ParentId = 0 },
                   new Item { Id = 2, Name = "Child1", ParentId = 1 },
                   new Item { Id = 3, Name = "Child2", ParentId = 1 },
                   new Item { Id = 4, Name = "GrandChild1", ParentId = 2 },
                   new Item { Id = 5, Name = "GrandChild2", ParentId = 2 },
                   new Item { Id = 6, Name = "GrandChild3", ParentId = 3 },
                   new Item { Id = 7, Name = "GrandChild4", ParentId = 3 },
                   new Item { Id = 8, Name = "Parent2", ParentId = 0 },
                   new Item { Id = 9, Name = "Child1", ParentId = 8 },
                   new Item { Id = 10, Name = "Child2", ParentId = 8 },
                   new Item { Id = 11, Name = "GrandChild1", ParentId = 9 },
                   new Item { Id = 12, Name = "GrandChild2", ParentId = 9 },
                   new Item { Id = 13, Name = "GrandChild3", ParentId = 10 },
                   new Item { Id = 14, Name = "GrandChild4", ParentId = 10 }
                };
            }
            public static void Recursive(int parentId, List<string> ancestors)
            {
                List<Item> children = items.Where(x => x.ParentId == parentId).ToList();
                if (children.Count  == 0)
                {
                    descendants.Add(string.Join(":", ancestors));
                }
                else
                {
                    foreach (Item child in children)
                    {
                        List<String> newAncestors = new List<string>(ancestors);
                        newAncestors.Add(child.Name);
                        Recursive(child.Id, newAncestors);
                    }
                }
            }
        }
    }
