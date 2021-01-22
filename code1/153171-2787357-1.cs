    public interface IProduct {
        int Quantity { get; }
        int Price { get; }
    }
    public partial class Product1:IProduct {
        int IProduct.Quantity { get { return Quantity; } }
        int IProduct.Price { get { return Price; } }
    }
    public partial class Product2:IProduct {
        int IProduct.Quantity { get { return Quantity; } }
        int IProduct.Price { get { return Price; } }
    }
