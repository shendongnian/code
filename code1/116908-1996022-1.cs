    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    interface IDisplayOrderable
    {
        int DisplayOrder { get; set; }
    }
    
    class ReorderableList<T> : IList<T> where T : IDisplayOrderable
    {
        List<T> list = new List<T>();
    
        private void updateDisplayOrders()
        {
            int displayOrder = 0;
            foreach (T t in list)
            {
                t.DisplayOrder = displayOrder++;
            }
        }
    
        public ReorderableList() { }
    
        public ReorderableList(IEnumerable<T> items)
        {
            list = new List<T>(items.OrderBy(item => item.DisplayOrder));
        }
    
        public void Insert(int index, T item)
        {
            list.Insert(index, item);
            updateDisplayOrders();
        }
    
        public void Add(T item)
        {
            list.Add(item);
            updateDisplayOrders();
        }
    
        public bool Remove(T item)
        {
            bool result = list.Remove(item);
            if (result)
                updateDisplayOrders();
            return result;
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }
    
        // TODO: Other members and methods required to implement IList<T>...    
    }
    
    class Item : IDisplayOrderable
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            Item foo = new Item { Name = "foo", DisplayOrder = 0 };
            Item bar = new Item { Name = "bar", DisplayOrder = 1 };
            Item baz = new Item { Name = "baz", DisplayOrder = 2 };
    
            // Pretend this came from the database.
            IEnumerable<Item> query = new Item[] { bar, foo };
            // The constructor automatically reorder the elements.
            ReorderableList<Item> items = new ReorderableList<Item>(query);
            items.Add(baz);
            items.Remove(foo);
            items.Insert(1, foo);
    
            foreach (Item item in items)
                Console.WriteLine("{0} : {1}", item.Name, item.DisplayOrder);
        }
    }
