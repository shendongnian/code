    public class MapeadorDataReaderListaObjetos
    {
    private Hashtable properties;
    private Hashtable Properties
    {
        get
        {
            if (properties == null)
                properties = new Hashtable();
            return properties;
        }
        set { properties = value; }
    }
    private void LoadProperties(object targetObject, Type targetType)
    {
        var flags = BindingFlags.DeclaredOnly| BindingFlags.Instance| BindingFlags.Public;
        if (properties == null)
        {
            List<PropertyInfo> propertyList = new List<PropertyInfo>();
            PropertyInfo[] objectProperties = targetType.GetProperties(flags);
            foreach (PropertyInfo currentProperty in objectProperties)
            {
                propertyList.Add(currentProperty);
            }
            properties = new Hashtable();
            properties[targetType.FullName] = propertyList;
        }
        if (properties[targetType.FullName] == null)
        {
            List<PropertyInfo> propertyList = new List<PropertyInfo>();
            PropertyInfo[] objectProperties = targetType.GetProperties(flags);
            foreach (PropertyInfo currentProperty in objectProperties)
            {
                propertyList.Add(currentProperty);
            }
            properties[targetType.FullName] = propertyList;
        }
    }
    public void MapearDataReaderListaObjetos <T> (IDataReader dr, List<T> Lista) where T: new()
    {
        Type businessEntityType = typeof(T);
        List<T> entitys = new List<T>();
        T miObjeto = new T();
        LoadProperties(miObjeto, businessEntityType);
        List<PropertyInfo> sourcePoperties = Properties[businessEntityType.FullName] as List<PropertyInfo>;
        while (dr.Read())
        {
            T newObject = new T();
            for (int index = 0; index < dr.FieldCount; index++)
            {
                for (int _indice = 0; _indice < sourcePoperties.Count; _indice++)
                {
                    if (sourcePoperties[_indice].Name.ToUpper() == dr.GetName(index).ToUpper())
                    {
                        string _tipoProp = sourcePoperties[_indice].PropertyType.ToString();
                        PropertyInfo info = sourcePoperties[_indice] as PropertyInfo;
                        if ((info != null) && info.CanWrite)
                        {
                            info.SetValue(newObject, dr.GetValue(index), null);
                        }
                    }
                }
            }
            entitys.Add(newObject);
        }
        dr.Close();
        Lista = entitys;
    }
}
