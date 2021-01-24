    private string GetValue(object obj, string property)
    {
        var value = "";
        try
        {
            value = obj.GetType().GetProperty(property).GetValue(obj).ToString();
        }
        catch { }
        return value;
    }
