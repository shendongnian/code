    public static List<Type> GetKnownTypesForDataContractSerializer()
    {
        Assembly a = Assembly.GetExecutingAssembly();
        Type[] array = a.GetExportedTypes();
        List<Type> lista = array.ToList();
        lista = lista.FindAll(item => ((item.IsClass || item.IsEnum) & !item.IsGenericType & !item.IsAbstract == true));
        List<Type> withEnumerable = new List<Type>();
        foreach (Type t in lista)
        {
            withEnumerable.Add(t);   //add basic type
            //now create List<> type
            Type listType = typeof(List<>);
            var listOfType = listType.MakeGenericType(t);
            withEnumerable.Add(listOfType);  //add Type of List<basic type>  
        }
        return withEnumerable;
    }
