    public in SaveCollection(DictionaryBase objCollection, string TableName, string spSave)
    {
        PropertyInfo propInfo;
    
       foreach (DictionaryEntry objClass in objCollection)
          {
               object tempObj = objClass.Value;
               propInfo = tempObj.GetType().GetProperty("TableFieldName");
    
               object[] obRetVal = new Object[0];
               object value = propInfo.GetValue(tempObj,obRetVal);
           }
    
    }
