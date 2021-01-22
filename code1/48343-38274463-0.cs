    Type typ = value.GetType();
    
    // Check for array type
    if(typeof(IEnumerable).IsAssignableFrom(typ) || typeof(IEnumerable<>).IsAssignableFrom(typ))
    { 
        List<object> list = ((IEnumerable)value).Cast<object>().ToList();
        //Serialize as an array with each item in the list...
    }
    else
    {
        //Serialize as object or value type...
    }
