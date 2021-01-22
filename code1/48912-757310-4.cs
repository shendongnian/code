    public struct MyAsset
    {
        public int ID;
        public string Name;
        public string Description;
    }
    public static MyAsset GetAsset(IDBConnection con, Int AssetId)
    {
        using (IDBCommand cmd = con.CreateCommand("sp_GetAsset"))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(cmd.CreateParameter("AssetID", DBType.Int, AssetId));
            using(IDataReader dr = cmd.ExecuteReader())
            {
                if (!dr.read()) 
                    return null;
                return new MyAsset() { 
                    ID = dr.GetInt32(dr[0]), 
                    Name = dr.GetString(dr[1]), 
                    Description = dr.GetString(dr[2])... 
                };
            }
        }
    }
