    public interface IOrder
    {
       string Name {get;set;}
       IList<IProduct> OrderedProducts {get;set;}
    }
