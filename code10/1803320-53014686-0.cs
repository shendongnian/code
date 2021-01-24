    private string GetSubProperty(object obj, string prop1, int whichItem, string prop2)
    {
        var o = obj.GetPropertyValue(prop1);
        int count = 0;
        foreach (object subObject in (IEnumerable)o)
        {
            if (whichItem == count++)
            {
                return subObject.GetPropertyValue(prop2).ToString();
            }
        }
        return null;
    }
