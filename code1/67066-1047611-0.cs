    private static readonly MethodInfo OfTypeMethod = 
         typeof(Enumerable).GetMethod("OfType");
    public List<IPart> Fetch(Type partType)
    {
        MethodInfo method = OfTypeMethod.MakeGenericMethod(partType);
        IEnumerable enumerable = (IEnumerable) method.Invoke(null, 
                                                         new object[] { PartList });
        return enumerable.Cast<IPart>().ToList();
    }
