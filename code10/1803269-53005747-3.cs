    DataTable dt = YourMethodName();
    var response = (from r in dt.AsEnumerable()
                    select new
                    {
                         panumber = r.Field<int>("panumber"),
                         //Do this for all remaing columns
                         admissiondate = r.Field<DateTime?>("admissiondate")?.ToString("MMMM yyyy, dd"),
                         dischargedate = r.Field<DateTime?>("dischargedate")?.ToString("MMMM yyyy, dd"),
                         txndate = r.Field<DateTime?>("txndate")?.ToString("MMMM yyyy, dd"),
                         //Do this for all remaing columns
                         comments = r.Field<string>("comments")
                    }
                   ).ToList();
