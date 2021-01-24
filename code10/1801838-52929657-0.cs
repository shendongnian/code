    [TestClass]
    public class Linq
    {
        [TestMethod]
        public void LaunchGetData()
        {
            int?[] ids = { 1, 3, 4, 6, null };
            var result = GetData(ids);
        }
        public List<ItemViewModel> GetDermiData()
        {
            var data = new List<ItemViewModel>();
            //Nullable data sample objects
            for (int i = 0; i < 5; i++)
            {
                data.Add(new ItemViewModel
                {
                    categoryId = null,
                    itemId = i + 11,
                    itemName = $"Item {i}"
                });
            }
            //Data sample objects with values
            for (int i = 0; i < 10; i++)
            {
                data.Add(new ItemViewModel
                {
                    categoryId = i,
                    itemId = i,
                    itemName = $"Item {i}"
                });
            }
            return data;
        }
        public List<ItemViewModel> GetData(int?[] categoryIds)
        {
            //I have replaced fetching information from the database with getting dermi data from a function.
            //You may still get your information from the database
            //var data = db.Query<ItemViewModel>("SELECT itemId, itemName, categoryId FROM items;").ToList();
            // So far so good. Getting data as List<ItemViewModel>
            var data = GetDermiData();
            // Now, if there are any categoryIds passed in to the controller, filter the data accordingly:
            if (categoryIds != null && categoryIds.Any())
            {
                data = data.Where(x => x.categoryId != null && categoryIds.Contains((int)x.categoryId)).ToList();
            }
            return data;
        }
    }
    public class ItemViewModel
    {
        public int itemId { get; set; }
        public string itemName { get; set; }
        public int? categoryId { get; set; }
    }
