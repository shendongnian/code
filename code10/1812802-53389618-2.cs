        var typ1 = typeof(List<>);
        var typ2 = typeof(IEnumerable<>);
        // true, List<>'s type definition contains an IEnumerable<>
        Console.WriteLine(IsAssignableToGenericType(typ1, typ2));
        // false, IEnumerable<>'s type definition does not contain List<>
        Console.WriteLine(IsAssignableToGenericType(typ2, typ1));
