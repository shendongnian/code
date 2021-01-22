    public interface ITax
    {
        decimal CalculateTax(decimal subtotal);
    }
    public class SaskatchewanTax : ITax
    {
        private readonly decimal provincialTaxRate;
        private readonly decimal federalTaxRate;
        public SaskatchewanTax(decimal federalTaxRate)
        {
            provincialTaxRate = 0.05m;
            this.federalTaxRate = federalTaxRate;
        }
        public decimal CalculateTax(decimal subtotal)
        {
            return provincialTaxRate * subtotal + federalTaxRate * subtotal;
        }
    }
    public class OntarioTax : ITax
    {
        private readonly decimal provincialTaxRate;
        private readonly decimal federalTaxRate;
        public OntarioTax(decimal federalTaxRate)
        {
            provincialTaxRate = 0.08m;
            this.federalTaxRate = federalTaxRate;
        }
        public decimal CalculateTax(decimal subtotal)
        {
            return provincialTaxRate * subtotal + federalTaxRate * subtotal;
        }
    }
