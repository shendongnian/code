    public List<string> GetPropertiesNameOfClass(object pObject)
    {
        List<string> propertyList = new List<string>();
        if (pObject != null)
        {
            foreach (var prop in pObject.GetType().GetProperties())
            {
                propertyList.Add(prop.Name);
            }
        }
        return propertyList;
    }
