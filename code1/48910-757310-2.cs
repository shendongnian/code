    public struct MyAsset
    {
        public int ID;
        public string Name;
        public string Description;
    }
    public static MyAsset GetAsset(Database db, DbCommand dbCommand)
    {
        using (IDataReader dr = db.ExecuteReader(dbCommand))
        {
            if (!dr.read()) 
                return null;
            return new MyAsset() { 
                ID = (int)dr(0), 
                Name = dr(1).ToString(), 
                Description = dr(2).ToString()... 
            };
        }
    }
