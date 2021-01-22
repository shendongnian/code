    public class Program
    {
        static void Main(string[] args)
        {
            var list = new DisplayOrderableList<MyItem>(p => p.DisplayOrder)
                           {
                               new MyItem{ Name = "Item 1"},
                               new MyItem{ Name = "Item 2"},
                               new MyItem{ Name = "Item 3"},
                           };
            var item = list.Where(p => p.Name == "Item 2").FirstOrDefault();
            list.MoveUp(item);
            list.ForEach(p => Console.WriteLine("{0}-{1}", p.Name, p.DisplayOrder));
            Console.WriteLine();
            list.MoveDown(item);
            list.ForEach(p => Console.WriteLine("{0}-{1}", p.Name, p.DisplayOrder));
            Console.WriteLine();
            Console.ReadLine();
        }
    }
