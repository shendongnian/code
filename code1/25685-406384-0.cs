    static void Foo<T>() where T : new()
    {
        T t = new T();
        string s = t.ToString(); // fine
        bool eq = t.Equals(t); // fine
        int hc = t.GetHashCode(); // fine
        Type type = t.GetType(); // BOOM!!!
    }
