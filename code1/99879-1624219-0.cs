     public int GetIntOrDefault(this DataReader dr, string fieldName, int defaultValue){
         var value = dr.GetOrdinal(fieldName);
         return (!dr.IsDBNull(value)) ? dr.GetInt32(value) : defaultValue;
     }
     internal SomeObject FillDataReader(IDataReader dr)
     {
        SomeObject obj = new SomeObject ();
        obj.ID = dr.GetInt32OrDefault("objectID", 0); // 1 line instead of 4
        ...
        return obj;
     }
