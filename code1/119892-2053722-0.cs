    public MemoryStream GetFileContents(IDataObject dataObject, int index)
    {
      MethodInfo getData = (
        from method in dataObject.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
        where method.Name=="GetData" && method.GetParameters().Length==4
        select method
      ).FirstOrDefault();
      if(getData==null)
      {
        FieldInfo innerField = (
          from field in dataObject.GetType().GetFields()
          where field.FieldType == typeof(IDataObject)
          select field
        ).FirstOrDefault();
        if(innerField==null) throw new Exception("Cannot get FileContents from DataObject of type" + dataObject.GetType());
        return GetFileContents((IDataObject)innerField.GetValue(dataObject), index);
      }
      return (MemoryStream)getData.Invoke(dataObject, new object[]
      {
        "FileContents", false,
        System.Runtime.InteropServices.ComTypes.DVASPECT.DVASPECT_CONTENT,
        index
      });
    }
