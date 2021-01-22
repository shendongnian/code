    public IEnumerable<SqlParameter> GetAndSetParameters(List<Tuple<string, string>> parameters){
                List<SqlParameter> paramlist = new List<SqlParameter>();
            
                foreach (var item in parameters)
            {
                paramlist.Add(new SqlParameter(item.Item1, item.Item2));
            }
            return paramlist;
        }
