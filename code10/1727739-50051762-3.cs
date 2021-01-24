    public abstract class  ProductData
    {
        public int Id { get; set; }
    } 
    public class FooData : ProductData
    {
        public string AlbumName { get; set; }
        public bool IsPlatinum { get; set; }
    }
    public class BarData : ProductData
    {
        public decimal PenPointSize { get; set; }
        public string InkColor { get; set; }
    }
