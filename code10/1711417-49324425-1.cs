    public IQueryable<T> GetActive()
        {
           var t = typeof(T);  
		   var isActiveProperty = t.GetProperty("IsActive");
		   var recordStatusCodeProperty=  t.GetProperty("RecordStatusCode");
		 
		 return DbContext.Set<T>().Where(x => (bool)isActiveProperty.GetValue(x, null) && recordStatusCodeProperty.GetValue(x, null).ToString() == "A");
        }
 
