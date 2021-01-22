    public static T MapStruct<T>(XmlRpcStruct xmlRpcStruct) where T : class, new()
    {
        return (T)MapStructInternal(typeof(T), xmlRpcStruct);
    }
    private static object MapStructInternal(Type t, XmlRpcStruct xmlRpcStruct)
    {
        object map = t.GetConstructor(new Type[0] ).Invoke(new object[0]);
        foreach (DictionaryEntry entry in xmlRpcStruct)
        {
            XmlRpcStruct entryStruct = (XmlRpcStruct)entry.Value;
            foreach (DictionaryEntry subEntry in entryStruct)
            {
                if (subEntry.Value.GetType() != typeof(XmlRpcStruct))
                {
                    var prop = map.GetType().GetField(subEntry.Key.ToString());
                    prop.SetValue(map, subEntry.Value);
                }
                else
                {
                    var prop = map.GetType().GetField(subEntry.Key.ToString());
                    prop.SetValue(map, MapStructInternal(map.GetType(),(XmlRpcStruct)subEntry.Value));
                }
            }
        }
        return map;
    }    
