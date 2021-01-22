    string memberid = HttpContext.Current.Session["MemberID"].ToString(); 
    string inhouse = HttpContext.Current.Session["Inhouse"].ToString();
    string supplier = HttpContext.Current.Session["Supplier"].ToString();
    bool includeInHouse = (inhouse == "Inhouse");
    bool includeSupplier = (supplier == "Supplier");
    
    MyEnts autocomplete = new MyEnts();
    var r = from p in autocomplete.tblAutoCompletes
                where (p.MemberId == memberid && p.LocationId == locationid && p.ACItem.Contains(prefixText))
                && (includeInHouse || (p.ACItem != "InHouse"))
                && (includeSupplier || (p.ACItem != "Supplier"))
                select p.ACItem;
    r.OrderBy(p => p.ACItem);
    return r.ToArray();
