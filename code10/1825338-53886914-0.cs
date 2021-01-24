    public List<T> GetData<T>(string Query_) where T : new()
           {
               SqlDataReader dr = DataReader(Query_);
               return  dr.MapToList<T>();
    
           }
