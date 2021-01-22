    public class Stamp: Product, IProduct
    {
        public double UnitPrice { get; set; }
    }
    public class TransitProduct: Product, IProduct
    {
        public double Weight { get; set; }
        public string Destination { get; set; }   
    }
    public class Letter: TransitProduct, IProduct
    {
    }
    public class Parcel: TransitProduct, IProduct
    {
        public double Size { get; set; }
    }
 
