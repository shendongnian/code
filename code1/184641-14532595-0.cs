    //Mapping null double?s to NaN when writing data.
    if (memberValue == null)
    {
        System.Reflection.PropertyInfo p = type.GetProperty(classMember.Name);
        if (p != null)
        {
            Type t = p.PropertyType; // t will be System.String
            if (t.IsEquivalentTo(typeof(Nullable<Double>)))
                memberValue = Double.NaN;
        }
    }
