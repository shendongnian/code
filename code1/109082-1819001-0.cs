    public static bool operator == (FakeEnum a, FakeEnum b) { 
        return object.Equals(a,b);
    }
    public static bool operator != (FakeEnum a, FakeEnum b) { 
        return !object.Equals(a,b);
    }
