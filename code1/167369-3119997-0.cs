    public class Vendor
    {
        private string vendorName = string.Empty; 
        public string VendorName
        {
            get { return vendorName; }
            set { vendorName = value; }
    
        public Vendor(string vn)
        {
            VendorName = vn;
        }
    }
