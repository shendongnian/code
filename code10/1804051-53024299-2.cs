    public Repere Select_detail_repere(string query)
    {
        Repere det = null; ;
        if (this.OpenConnection() == true)
        {
            IDataReader dataReader = ExecuteReader(query);
            bool containsModification = CheckIfDataContains(dataReader, "MODIFICATIONS");
            while (dataReader.Read())
            {
                det = new Repere();
                det.Name = (dataReader["DET_NOM"] ?? string.Empty).ToString().Trim();
                if(containsModification)
                {
                     det.Modifies = dataReader["MODIFICATIONS"].ToString().Trim();
                }
                else
                {
                     det.Modifies = "";
                }
                det.Profil = (dataReader["DET_PRF"] ?? string.Empty).ToString().Trim();
                det.Matiere = (dataReader["DET_MAT"] ?? string.Empty).ToString().Trim();
                ...
             }
             this.CloseConnection();
          }
          return det;
      }
      public bool CheckIfDataContains(IDataReader dataReader,string columnName)
        {
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                if (dataReader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                return true;
            }
            return false;
        }
