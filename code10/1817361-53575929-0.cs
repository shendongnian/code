    interface IFormatter
    {
       string Serialize(object o);
       object Deserialize(string s);
    }
    interface IFormatter<T> : IFormatter
    {
       string Serialize(T o);
       T Deserialize<T>(string s);
    }
