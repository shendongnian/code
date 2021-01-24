    class Program
    {
        static void Main(string[] args)
        {
            var stubList = new List<Item>
            {
                new Item()
            };
            var m = (stubList, 1);
            var mockRepository = Mock.Of<IRepository>(r => r.GetItems(50) == Task.FromResult(m));
        }
    }
    interface IRepository
    {
        Task<(IEnumerable<Item>, int)> GetItems(int total);
    }
    class Item
    {
    }
