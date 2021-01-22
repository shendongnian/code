    public BuilderInclusionsForm(Product p) : this()
    {            
        MethodInfo method = typeof(BuilderInclusionsForm).GetMethod("FindProduct",
             BindingFlags.Static | BindingFlags.NonPublic);
        MethodInfo concrete = method.MakeGenericMethod(new Type[] { p.GetType() });
        product = (Product) concrete.Invoke(null, new object[] { p });
    }
