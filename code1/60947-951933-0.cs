    class Program
    {
        static void Main(string[] args)
        {
            List<Item> first = GetItems("F891778E-9C87-4620-8AC6-737F6482CECB").ToList();
            List<Item> second = GetItems("7CA18DD1-E23B-41AA-871B-8DEF6228F96C").ToList();
            Console.WriteLine(first.Count);
            Console.WriteLine(second.Count);
            Console.Read();
        }
        static IEnumerable<Item> GetItems(string vendorId)
        {
            using (Database repo = new Database(@"connection_string_here"))
            {
                return repo.GetTable<Item>().Where(i => i.VendorId.ToString() == vendorId).ToList(); ;
            }
        }
    }
