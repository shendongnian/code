    public List<Member> GetData()
    {
        var dt = new DataTable();
        var cn = @"Your Connection String";
        var cmd = @"Your Select Command";
        using (var da = new SqlDataAdapter(cmd, cn))
            da.Fill(dt);
        return dt.AsEnumerable().AsEnumerable().Select(r=>{
            id = r.Field<int>("id"),
            name = r.Field<string>("name"),
            age = r.Field<int>("age")
        }).ToList();
    }
