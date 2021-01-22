    public interface IAmount
    {
        decimal Field
        { get; set; }
    }
    
    public class SomeAmount : IAmount
    {
        public decimal Amount
        { get; set; }
    
        decimal IAmount.Field
        {
            get { return Amount; }
            set { Amount = value; }
        }
    }
    
    public class SomeGrossAmount : IAmount
    {
        public decimal GrossAmount
        { get; set; }
    
        decimal IAmount.Field
        {
            get { return GrossAmount; }
            set { GrossAmount= value; }
        }
    }
