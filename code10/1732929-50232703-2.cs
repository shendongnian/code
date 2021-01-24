    static string GetString(object myObject)
    {
        string values = string.Empty;
        if (myObject != null)
        {
            foreach (System.Reflection.PropertyInfo pi in myObject.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(Profession))
                    values += "{" + GetString(pi.GetValue(myObject)) + "}, ";
                else
                    values += pi.Name + ": " + pi.GetValue(myObject) + ", ";
            }
        }
        return values.Substring(0, Math.Max(0, values.Length - 2));
    }
