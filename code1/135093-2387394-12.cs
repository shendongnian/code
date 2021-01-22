        public List<T> ReturnList<T>(T sample)
        {
            try
            {
                List<T> fdList = new List<T>();
                myCommand.CommandText = QueryString;
                SqlDataReader nwReader = myCommand.ExecuteReader();
                var properties = TypeDescriptor.GetProperties(sample);
                if (nwReader != null)
                {
                    while (nwReader.Read())
                    {
                        int objIdx = 0;
                        object[] objArray = new object[properties.Count];
                        for (int i = 0; i < nwReader.FieldCount; i++)
                        {
                            foreach (PropertyDescriptor info in properties) // FieldInfo info in typeFields)
                            {
                                if (info.Name == nwReader.GetName(i))
                                {
                                    objArray[objIdx++] = nwReader[info.Name];
                                    break;
                                }
                            }
                        }
                        fdList.Add((T)Activator.CreateInstance(sample.GetType(), objArray));
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
