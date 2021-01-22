    var result = from r 
        in fips.AsEnumerable() 
        select new
        {
            FacProcess = r.Field<string>("FACILITY_PROCESS_SUB_GROUP_CODE"),
            GroupName = r.Field<string>("PROCESS_SUB_GROUP_NAME"),
            Item3 = r.Field<string>("Item3")
        }
        distinct;
