    public object ConvertArraysToIList(object returnObj)    
    {
    if (returnObj != null)
    {
        var allProps = returnObj.GetType().GetProperties().Where(p => p.PropertyType.IsPublic 
            && p.PropertyType.IsGenericType 
            && p.PropertyType.Name==typeof(IList<>).Name).ToList();
        foreach (var prop in allProps)
        {
            var value = prop.GetValue(returnObj,null);
            //set the current property to a new instance of the IList<>
            var arr=(System.Array)value; 
            Type listType=null;
            if(arr!=null)
            {
                listType= arr.GetType().GetElementType();
            }
            
            //create an empty list of the specific type
            var listInstance = typeof(List<>)
              .MakeGenericType(listType)
              .GetConstructor(Type.EmptyTypes)
              .Invoke(null);
            foreach (var currentValue in arr)
            {
                listInstance.GetType().GetMethod("Add").Invoke(listInstance, new[] { currentValue });
            }
            prop.SetValue(returnObj, listInstance, null);
        }
    }
   
    return returnObj;
    }
