    public static class MyBaseClassExtender
    {
        public static void Retrieve(this MyBaseClass entity, int ID)
        {
            string className = entity.GetType().Name;
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(String.Format("{0}s_Retrieve_{0}", className));
            db.AddInParameter(dbCommand, String.Format("@{0}ID", className), DbType.Int32, ID);
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {
                    BOLoader.LoadDataToProps(this, dr);
                }
            }
        }
    }
