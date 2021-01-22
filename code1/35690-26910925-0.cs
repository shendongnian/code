    using System.Reflection;
    
    void ListAllColors()
    {
        Type colorsType = typeof(System.Windows.Media.Colors);
        PropertyInfo[] colorsTypePropertyInfos = colorsType.GetProperties(BindingFlags.Public | BindingFlags.Static);
    
        foreach (PropertyInfo colorsTypePropertyInfo in colorsTypePropertyInfos)
            Debug.WriteLine(colorsTypePropertyInfo.Name);
    }
