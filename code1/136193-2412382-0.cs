    public class SomeGrossAmount : IAmount
    {
        public decimal GrossAmount { get; set; }
        decimal IAmount.Amount
        {
            get { return GrossAmount; }
            set { GrossAmount = value; }
        }   
    }
