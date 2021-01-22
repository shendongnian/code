    [DataMethod(), AxSessionPermission(SecurityAction.Assert)]
    public static System.Data.DataTable GetCustBuckets(String AccountNum)
    {
        //Report Parameters
        Dictionary<string, object> d = new Dictionary<string, object>();
        d.Add("CustTransOpen.AccountNum",AccountNum);
               
        // Create a data table. Add columns for item group and item information. 
        DataTable table = new DataTable();
        table = AxQuery.ExecuteQuery("SELECT * FROM epcCustomerAging",d);
       
        DataTable tableBucket = new DataTable();
        DataRow rowBucket;
        tableBucket.Columns.Add("Current", typeof(double));
        tableBucket.Columns.Add("Bucket31to60", typeof(double));
        tableBucket.Columns.Add("Bucket61to90", typeof(double));
        tableBucket.Columns.Add("Bucket91to120", typeof(double));
        tableBucket.Columns.Add("Over120", typeof(double));
        //Variables to hold BUCKETS
        double dCurrent = 0;
        double dBucket31to60 = 0;
        double dBucket61to90 = 0;
        double dBucket91to120 = 0;
        double dOver120 = 0;
        
        // Iterate through the results. Add the item group to the data table. Call the display method 
        foreach (DataRow TransRow in table.Rows)
        {
            DateTime TransDate = Convert.ToDateTime(TransRow["TransDate"].ToString());
            double AmountCur = Convert.ToDouble(TransRow["AmountCur"].ToString());
            
            DateTime Today= Microsoft.VisualBasic.DateAndTime.Now;
            long nDays = Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Day, TransDate, Today, 0, 0);
            if (nDays <= 30)
            {               
                dCurrent += AmountCur; 
            }
            else if (nDays <= 60)
            {
                 dBucket31to60 += AmountCur ; 
            }
            else if (nDays <= 90)
            {
                dBucket61to90 += AmountCur;
            }
            else if (nDays <= 120)
            {
                dBucket91to120 += AmountCur;
            }
            else
            {
                dOver120 += AmountCur;    
            }
        }
        rowBucket = tableBucket.NewRow();
        rowBucket["Current"] = dCurrent;
        rowBucket["Bucket31to60"] = dBucket31to60;
        rowBucket["Bucket61to90"] = dBucket61to90;
        rowBucket["Bucket91to120"] = dBucket91to120;
        rowBucket["Over120"] = dOver120;
        tableBucket.Rows.Add(rowBucket);
        return tableBucket;
    }
