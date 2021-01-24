    public class PR_Product
    {
        public int ID_Product { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool InProduction { get; set; }
    }
    public class PR_ProductInsuranceProduct
    {
        public int ID_ProductInsuranceProduct { get; set; }
        public int ID_Product { get; set; }
    }
