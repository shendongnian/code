    //during storage:
    Type elementType = myList.GetType().GetGenericTypeDefinition().GetGenericArguments[0];
    string typeNameToSave = elementType.FullName;
    //during retrieval
    string typeNameFromDatabase = GetTypeNameFromDB();
    Type elementType = Type.GetType(typeNameFromDatabase);
    Type listType = typeof(List<>).MakeGenericType(new Type[] { elementType });
