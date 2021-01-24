    public class FruitProduct : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Variety { get; set; }
    }
    public class CerealProduct : IProduct
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public int SugarContent { get; set; }
    }
