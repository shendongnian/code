    class Program
    {
        class test
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Owner { get; set; }
            public DateTime DateAdded { get; set; }
        }
        static void Main(string[] args)
        {
            List<test> listOrder = new List<test>();
            listOrder.Add(new test() { Id = 1, Name = "john", Description = "test", Owner = "test", DateAdded = DateTime.Now });
            listOrder.Add(new test() { Id = 1, Name = "max", Description = "test1", Owner = "test1", DateAdded = DateTime.Now });
            listOrder.Add(new test() { Id = 1, Name = "phil", Description = "test2", Owner = "test2", DateAdded = DateTime.Now });
            List<test> sortbyName = listOrder.OrderBy(item => item.Name).ToList();
            List<test> sortbyDescription = listOrder.OrderBy(item => item.Description).ToList();
            List<test> sortbyOwner = listOrder.OrderBy(item => item.Owner).ToList();
        }
    }
