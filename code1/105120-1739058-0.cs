    static Array CreateJaggedArray(Type elementType, params int[] lengths)
    {
        Type type = elementType;
        for (int i = 0; i < lengths.Length - 1; i++)
        {
            type = type.MakeArrayType();
        }
        return InitializeJaggedArray(type, 0, lengths);
    }
    static Array InitializeJaggedArray(Type type, int index, params int[] lengths)
    {
        Array array = Array.CreateInstance(type, lengths[index]);
        Type elementType = type.GetElementType();
        if (elementType != null)
        {
            for (int i = 0; i < lengths[index]; i++)
            {
                array.SetValue(
                    InitializeJaggedArray(elementType, index + 1, lengths), i);
            }
        }
        return array;
    }
