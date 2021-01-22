    using System;
    using System.Collections.Generic;
    
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
            ReorderableList<Item> items = new ReorderableList<Item>();
            Item foo = new Item { Name = "foo" };
            Item bar = new Item { Name = "bar" };
            Item baz = new Item { Name = "baz" };
            items.Add(foo);
            items.Insert(0, bar);
            items.Add(baz);
            items.Remove(foo);
    
            foreach (Item item in items)
                Console.WriteLine("{0} : {1}", item.Name, item.DisplayOrder);
        }
    }
