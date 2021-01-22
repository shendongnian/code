    public ConvertToList<T>(SqlDataReader sqldr, int index)
            {
                List<T> list = new List<T>();
    
                while (sqldr.Read())           {
                   list.Add((T)sqldr.GetValue(index));               index++;   
                }
    
                return list;
            }
