    var aliasProperty = list.Where( t => t.Name == "Banana" )
        .GetProperties(BindingFlags.Static | BindingFlags.Public)
        .Single( p => p.Name == "Alias" );
    var currentValue = aliasProperty.Invoke(null) as string;
    Console.WriteLine(currentValue); //Should be "banana"
