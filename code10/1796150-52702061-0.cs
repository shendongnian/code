    public interface IStock
    {
        Product Product { get; set; }
        int Quantity { get; set; }
        bool IsBatchNumberManaged { get; }
        string BatchNumber { get; set; }
        bool IsSaleDeadlineDateManaged { get; }
        DateTime? SaleDeadlineDate { get; set; }
    }
    public class Stock : IStock
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public IsBatchNumberManaged { get { return BatchNumber != null;} }
        string BatchNumber { get; set; }
        IsSaleDeadlineDateManaged { get { return SaleDeadlineDate != null;} }
        DateTime? SaleDeadlineDate { get; set; }    
    }
