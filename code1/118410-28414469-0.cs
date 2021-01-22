    var nr = "751212";
    var century = DateTime.Now.AddYears(-100).Year.ToString().Substring(0, 2);
    var days = (DateTime.Now - DateTime.Parse(century + nr)).Days;
    decimal years = days / 365.25m;
    if(years>=99)
     century = DateTime.Now.Year.ToString().Substring(0, 2);
    
    var fullnr = century+nr;
