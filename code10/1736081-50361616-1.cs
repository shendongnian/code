    public void GetData(object obj, Type objType, string find)
    {
        //as you are passing type of list here, you can use it.
        if(objType == typeof(ABC))
        {
            List<ABC> list = (List<ABC>)obj;
            //now use it.
            //here we are getting the property with name as per find (name we passed in method)
            PropertyInfo prop = objType.GetProperty(find);
            //if there is no property with specified name, PropertyInfo object (prop) will be null
            if (prop != null)
            {
                if (prop.PropertyType == typeof(int))
                {
                    foreach (ABC abcObj in list)
                    {
                        object a1Data = prop.GetValue(abcObj);
                        int data = (int)a1Data;
                    }
                }
            }
        }
    }
