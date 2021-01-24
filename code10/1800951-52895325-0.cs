    [HttpPost]
    public ActionResult upload(HttpPostedFileBase uploadFile)
    {
        private DB_Entities db = new DB_Entities();
        DataSet ds = GetFileExcel(uploadFile);
        string[] countryCodes = ds.Tables["Header$"].AsEnumerable().Select(row => row.Field<string>("country")).ToArray();
        var selectedCountries = db.tbl_Item.Where(q => countryCodes.Contains(q)).Select(s => new { Id = s.Id, Code = s.Code }).ToList();
        List<tbl_header>  headers = ds.Tables["Header$"].AsEnumerable().Select
        (
            row => new tbl_header
            {
                name = row.Field<string>("Name") == string.Empty ? 0 : int.Parse(row.Field<string>("Name")),
                address = row.Field<string>("Address") == string.Empty ? DateTime.MinValue : DateTime.ParseExact((row.Field<string>("Address")), "dd MMM yyyy", provider),
                country = selectedCountries.SingleOrDefault(q=> q.Code == row.Field<string>("Country")).Id
            }
        ).ToList();
        db.tbl_header.AddRange(headers);
        db.SaveChanges();
    }
