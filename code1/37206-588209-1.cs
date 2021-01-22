    var allMethods = typeof (Example).GetMethods(BindingFlags.Public | BindingFlags.Static);
    MethodInfo foundMi = allMethods.FirstOrDefault(
        mi => mi.Name == "Foo" && mi.GetGenericArguments().Count() == 2);
    if (foundMi != null)
    {
        MethodInfo closedMi = foundMi.MakeGenericMethod(new Type[] {typeof (int), typeof (string)});
        Example example= new Example();
        closedMi.Invoke(example, new object[] { 5 });
    }
