    /// <summary>
    /// For the given type, returns its representation in C# code.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="genericArgs">Used internally, ignore.</param>
    /// <param name="arrayBrackets">Used internally, ignore.</param>
    /// <returns>The representation of the type in C# code.</returns>
    public static string GetTypeCSharpRepresentation(Type type, Stack<Type> genericArgs = null, StringBuilder arrayBrackets = null)
    {
        StringBuilder code = new StringBuilder();
        Type declaringType = type.DeclaringType;
            
        bool arrayBracketsWasNull = arrayBrackets == null;
        if (genericArgs == null)
            genericArgs = new Stack<Type>(type.GetGenericArguments());
            
        int currentTypeGenericArgsCount = genericArgs.Count;
        if (declaringType != null)
            currentTypeGenericArgsCount -= declaringType.GetGenericArguments().Length;
        Type[] currentTypeGenericArgs = new Type[currentTypeGenericArgsCount];
        for (int i = currentTypeGenericArgsCount - 1; i >= 0; i--)
            currentTypeGenericArgs[i] = genericArgs.Pop();
            
        if (declaringType != null)
            code.Append(GetTypeCSharpRepresentation(declaringType, genericArgs)).Append('.');
            
        if (type.IsArray)
        {
            if (arrayBrackets == null)
                arrayBrackets = new StringBuilder();
                
            arrayBrackets.Append('[');
            arrayBrackets.Append(',', type.GetArrayRank() - 1);
            arrayBrackets.Append(']');
                
            Type elementType = type.GetElementType();
            code.Insert(0, GetTypeCSharpRepresentation(elementType, arrayBrackets : arrayBrackets));
        }
        else
        {
            code.Append(new string(type.Name.TakeWhile(c => char.IsLetterOrDigit(c) || c == '_').ToArray()));
                
            if (currentTypeGenericArgsCount > 0)
            {
                code.Append('<');
                for (int i = 0;  i < currentTypeGenericArgsCount;  i++)
                {
                    code.Append(GetTypeCSharpRepresentation(currentTypeGenericArgs[i]));
                    if (i < currentTypeGenericArgsCount - 1)
                        code.Append(',');
                }
                code.Append('>');
            }
                
            if (declaringType == null  &&  !string.IsNullOrEmpty(type.Namespace))
            {
                code.Insert(0, '.').Insert(0, type.Namespace);
            }
        }
            
        if (arrayBracketsWasNull  &&  arrayBrackets != null)
            code.Append(arrayBrackets.ToString());
        return code.ToString();
    }
