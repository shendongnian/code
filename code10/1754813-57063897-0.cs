        var hash = new System.HashCode();
        foreach (var obj in myObjs)
        {
            hash.Add(obj.myStringProp, System.StringComparer.OrdinalIgnoreCase);
            hash.Add(obj.myLongProp);
            hash.Add(obj.myEnumProp);
        }
        return hash.ToHashCode();
