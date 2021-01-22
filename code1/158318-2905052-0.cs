    public static List<Post> ListFromDataSet(DataSet ds)
    {
        return ds.Tables[0].AsEnumerable()
                           .Select(row => Post.FromDataRow(row))
                           .ToList();
    }
