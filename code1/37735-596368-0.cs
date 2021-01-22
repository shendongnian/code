    public class VendorApplicationBatch  {
        private IList<VendorApplication> Applications {get; set;};   
 
        public decimal CaculateBatchTotal()
        {
            if (Applications == null || Applications.Count == 0)
                throw new ArgumentException("There were no applications for this batch, that shouldn't be possible");
     
            decimal Total = 0m;
            foreach (VendorApplication App in Applications)
                Total += App.Amount;
           return Total;
        }
    }
