    public class VatItem 
    {
        //Did not used decimal type because I don't know how JSON.NET handles it
        public double VAT_PERCENT { get; set; }
        public double COMPLETE_NET { get; set; }
        public double VAT_VALUE { get; set; }
    }
