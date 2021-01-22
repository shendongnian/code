    public class MyAsset
    {
        public int ID;
        public string Name;
        public string Description;
    }
    public MyAsset GetAsset(IDBConnection con, Int AssetId)
    {
        using (var cmd = con.CreateCommand("sp_GetAsset"))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(cmd.CreateParameter("AssetID"));
            using(IDataReader dr = cmd.ExecuteReader())
            {
                if (!dr.Read()) return null;
                return new MyAsset() { 
                    ID = dr.GetInt32(0), 
                    Name = dr.GetString(1), 
                    Description = dr.GetString(2)
                };
            }
        }
    }
