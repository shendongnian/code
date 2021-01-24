    // Note this is assuming you can use the new ValueTuples, if not
    // then you can change the return to Tuple<string, MyObject>
    public static (string key, MyObject myObject) ExtensionMethod(this IEnumerable<KeyValuePair<string, MyObject>> items)
    {
        // Do whatever it was you were doing here in the original code
        // except now you are operating on KeyValuePair objects which give
        // you both the object and the key
        foreach(var pair in items)
        {
             if ( YourCondition ) return (pair.Key, pair.Value);
        }
    }
