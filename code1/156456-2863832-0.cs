    System.Reflection.MemberInfo inf = typeof(Wahala);
    object[] attributes;
    attributes = 
       inf.GetCustomAttributes(
            typeof(DescriptionAttribute), false);
    foreach(Object attribute in attributes)
    {
        DescriptionAttribute da = (DescriptionAttribute)attribute;
        Console.WriteLine("Description: {0}", da.Description);
    }
