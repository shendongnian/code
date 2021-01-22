    public class City
    {
        public int Id;
        public int? ParentId;
        public string CityName;
    }
    public class ProductCategory
    {
        public int Id;
        public int? ParentId;
        public string Category;
        public int Price;
    }
    public class Test
    {
        public void f()
        {
            List<City> city = new List<City>();
            city.Add(new City() { Id = 1, ParentId = 0, CityName = "China" });
            city.Add(new City() { Id = 2, ParentId = null, CityName = "America" });
            city.Add(new City() { Id = 3, ParentId = 1, CityName = "Guangdong" });
            int searchedId = 0;
            IList<City> results = city.FindAll(delegate(City c)
                                                   {
                                                       return c.ParentId.HasValue &&
                                                              c.ParentId == searchedId;
                                                   });
        }
    }
