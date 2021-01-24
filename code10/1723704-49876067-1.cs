    class Program
    {
        static void Main(string[] args)
        {
            CancelReason ad = new CancelReason();
            ad.BusinessLineID = 1;
            ad.CancelReasonCodeID = 2;
            ad.CancelRefund = "C";
            ad.CompanyID = 0;
            ad.DBOperation = 1;
            ad.Description = "test";
            ad.IsActive = "Y";
            ad.ReasonCode = "TestCode";
            ad.UpdateStamp = new byte[] { 1, 2, 3, 4 };
            
            DataTable dt = ad.ConvertToDataTable(s => new { s.DBOperation, s.BusinessLineID, s.LoggedInUser }, r => new { Refund = r.CancelRefund, Company = r.CompanyID });
        }
    }
