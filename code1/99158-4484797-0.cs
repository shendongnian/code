    public class Order
    {
        public Order(ITaxCalculator taxCalculator)
        {
            CalculateTax = new Func<Func<decimal>>(() =>
            {
                decimal? tax = null;
                return () =>
                {
                    if (!tax.HasValue)
                    {
                        tax = taxCalculator.Calculate(this);
                    }
                    return tax.Value;
                };
            })();
        }
     
        public Func<decimal> CalculateTax { get; set; }
     
        ...
    }
