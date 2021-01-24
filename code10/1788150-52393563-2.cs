    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    public class CustomAttr : Attribute
    {
        public CustomAttr():base()
            {}
    
        public CustomAttr(int Order)
        {
            this.Order = Order;
        }
        public int Order {get ; set ; }
    
    }
    public abstract class BaseClass
    {
        public int Id { get; set; }
    
        [CustomAttr(Order = 20)]
        public string Name { get; set; }
    
        public string Description { get; set; }
    
        public string Owner { get; set; }
    
        public DateTime DateAdded { get; set; }
    }
    
    public class Foo : BaseClass
    {
        [CustomAttr(Order = 2)]
        public string Country { get; set; }
    
        [CustomAttr(Order = 5)]
        public decimal Amount { get; set; }
    
        public string Other { get; set; }
    }
    
    public class Bar : BaseClass
    {
        [CustomAttr(Order = 3)]
        public string Organization { get; set; }
    
        [CustomAttr(Order = 1)]
        public string Keywords { get; set; }
    }
    class app
    {
         
    
        static void Main()
        {
            List<Bar> listToOrder = new List<Bar>();
            listToOrder.Add(new Bar() { Id = 5, Keywords = "Hello", Organization = "Arlando" });
            listToOrder.Add(new Bar() { Id = 12, Keywords = "Table", Organization = "Fuelta" , Name = "Deep"});
        listToOrder.Add(new Bar() { Id = 12, Keywords = "Table", Organization = "Fuelta", Name = "Inherit" });
        listToOrder.Add(new Bar() { Id = 1, Keywords = "Muppet", Organization = "Coke" });
            listToOrder.Add(new Bar() { Id = 6, Keywords = "Grumpy", Organization = "Snow" });
            listToOrder.Add(new Bar() { Id = 9, Keywords = "Johny", Organization = "White" });
            listToOrder.Add(new Bar() { Id = 12, Keywords = "Table", Organization = "Bruno" });
            listToOrder.Add(new Bar() { Id = 12, Keywords = "Table", Organization = "Fuelta" });
            listToOrder.Add(new Bar() { Id = 7, Keywords = "Set", Organization = "Voltra" });
            listToOrder.Add(new Bar() { Id = 45, Keywords = "Brr", Organization = "Elvis" });
            listToOrder.Add(new Bar() { Id = 15, Keywords = "Tsss", Organization = "Marion" });
    
            OrderComparer<Bar> myOrder = new OrderComparer<Bar>();
            listToOrder.Sort(myOrder);
    
            foreach (Bar oneBar in listToOrder)
            {
                Console.WriteLine(oneBar.Id + " " + oneBar.Keywords + " " + oneBar.Organization);
            }
    
            Console.ReadKey();
        }
    
        private class OrderComparer<T> : IComparer<T>
        {
            SortedList<int, PropertyInfo> sortOrder = new SortedList<int, PropertyInfo>();
    
            public OrderComparer()
            {
                Type objType = typeof(T);
                foreach (PropertyInfo oneProp in objType.GetProperties())
                {
                    CustomAttr customOrder = (CustomAttr) oneProp.GetCustomAttribute(typeof(CustomAttr), true);
                    if (customOrder == null) continue;
                    sortOrder.Add(customOrder.Order, oneProp);
                }
            }
            public int Compare(T x, T y)
            {
                Type objType = typeof(T);
                int result = 0;
                int i = 0;
    
                while (result == 0 && i < sortOrder.Count)
                {
                    result = ((IComparable)sortOrder.ElementAt(i).Value.GetValue(x)).CompareTo(sortOrder.ElementAt(i).Value.GetValue(y));
                    i++;
                }
    
                return result;
            }
        }
    }
