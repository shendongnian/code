    //most likely populate from db
    var counties = new List<County>();
    var dekalb = new County { CountyName = "DEKALB" };
    
    dekalb.CommonMisspellings.Add("DE KALB");
    dekalb.CommonMisspellings.Add("DE_KALB");
    
    var test = "DE KALB";
    
    if (counties.Any(c => c.CommonMisspellings.Contains(test)))
    {
        test = counties.First(c => c.CommonMisspellings.Contains(test)).CountyName;
    }
