    if (TryDeserialize<TypeA, List<TypeB>>(json2, out obj))
    {
        if (obj is TypeA)
        {
            var r = obj as TypeA;
        }
        else
        {
            var r = obj as List<TypeB>;
        }
    }
