    using (var dateRn = xlApp.Range["A1"].WithComCleanup())
    {
        dateRn.Resource.Value2 = Convert.ToDateTime(dateRn.Resource.Value2).ToString("dd-MMM-yyyy");
    }
    
    
    using (var rn = xlApp.Range["A1:A10"].WithComCleanup())
    {
        rn.Resource.Select();
        rn.Resource.NumberFormat =  "d-mmm-yyyy;@";
    }
