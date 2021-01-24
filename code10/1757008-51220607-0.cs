    public List<Profil> Select_profil(string query)
            {
                List<Profil> list = new List<Profil>();
                if (this.OpenConnection() == true)
                {
                    IDataReader dataReader = ExecuteReader(query);
                    while (dataReader.Read())
                    {
                        ...
                        ...
                    }
                    this.CloseConnection();
                }
                return list;
            }
