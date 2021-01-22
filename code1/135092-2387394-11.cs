        public List<T> ReturnList<T>() where T : new()
        {
            try
            {
                List<T> fdList = new List<T>();
                myCommand.CommandText = QueryString;
                SqlDataReader nwReader = myCommand.ExecuteReader();
                Type objectType = typeof (T);
                PropertyInfo[] typeFields = objectType.GetProperties();
                if (nwReader != null)
                {
                    while (nwReader.Read())
                    {
                        T obj = new T();
                        for (int i = 0; i < nwReader.FieldCount; i++)
                        {
                            foreach (PropertyInfo info in typeFields)
                            {
                                // Because the class may have fields that are *not* being filled, I don't use nwReader[info.Name] in this function.
                                if (info.Name == nwReader.GetName(i))
                                {
                                    if (!nwReader[i].Equals(DBNull.Value)) 
                                        info.SetValue(obj, nwReader[i], null);
                                    break;
                                }
                            }
                        }
                        fdList.Add(obj);
                    }
                    nwReader.Close();
                }
                return fdList;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
