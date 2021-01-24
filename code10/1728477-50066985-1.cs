    //using System.Reflection;
    FieldInfo[] KratosFields = typeof(Kratos).GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
    foreach (FieldInfo fi in KratosFields)
    {
        System.Diagnostics.Debug.WriteLine("[" + fi.MemberType.ToString() + "]" + fi.Name + "::" + fi.FieldType.Name);
    }
    PropertyInfo[] KratosProps = typeof(Kratos).GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
    foreach (PropertyInfo pi in KratosProps)
    {
        System.Diagnostics.Debug.WriteLine("[" + pi.MemberType.ToString() + "]" + pi.Name + "::" + pi.PropertyType.Name);
    }
