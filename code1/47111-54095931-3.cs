    public static V ConvertParentObjToChildObj<T,V> (T obj) where V : new()
    {
        Type typeT = typeof(T);
        PropertyInfo[] propertiesT = typeT.GetProperties();
        V newV = new V();
        foreach (var propT in propertiesT)
        {
            var nomePropT = propT.Name;
            var valuePropT = propT.GetValue(obj, null);
            Type typeV = typeof(V);
            PropertyInfo[] propertiesV = typeV.GetProperties();
            foreach (var propV in propertiesV)
            {
                var nomePropV = propV.Name;
                if(nomePropT == nomePropV)
                {
                    propV.SetValue(newV, valuePropT);
                    break;
                }
            }
        }
        return newV;
    }
