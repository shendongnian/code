    using System;
    static class Program
    {
        static object ToDbObject(this object value)
        {
            return value ?? DBNull.Value;
        }
        static void Main(string[] args)
        {
            int? imageId = 3; 
            DateTime? actionDate = null;
            Console.WriteLine("ImageId {0}: [{1}] - {2}", imageId, imageId.ToDbObject(), imageId.ToDbObject().GetType());
            Console.WriteLine("actionDate {0}: [{1}] - {2}", actionDate, actionDate.ToDbObject(), actionDate.ToDbObject().GetType());
            Console.ReadKey();
        } 
    }
