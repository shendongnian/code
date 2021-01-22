    public abstract class Tax
    {
        protected decimal ProvincialTaxRate; // Yes, you are Canadian ;)
        public decimal CalculateTax(decimal subtotal)
        {
            return ProvincialTaxRate * subtotal + FederalTaxRate * subtotal;
        }
        decimal FederalTaxRate = new decimal(0.20f);
    }
    public class SaskatchewanTax : Tax
    {
        public SaskatchewanTax()
        {
            base.ProvincialTaxRate = new decimal(0.05f);
        }
    }
    public class OntarioTax : Tax
    {
        public OntarioTax()
        {
            base.ProvincialTaxRate = new decimal(0.08f);
        }
    }
