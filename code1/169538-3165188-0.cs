    static class Extensions
    {
        public static bool In<T>(this T item, params T[] items)
        {
            if (items == null)
                throw new ArgumentNullException("items");
            return items.Contains(item);
        }
    }
    class Program
    {
        static void Main()
        {
            int myValue = 1;
            if (myValue.In(1, 2, 3))
                // Do Somthing...
            string ds = "Bob";
            if (ds.In("andy", "joel", "matt")) 
            // Do Someting...
        }
    }
