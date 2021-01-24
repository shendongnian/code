    for (var i = 0; i < properties.Length; i++)
    {
        object value = properties[i].GetValue(this);
        if (value == null)
        {
            //do nothing
        }
        else if (value is DateTime)
        {
             output += ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
        }
        else
        {
             output += value.ToString();
        }
        if (i != properties.Length - 1)
        {
            output += ",";
        }
    }
