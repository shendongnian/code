    public static bool operator==(Foo a, Foo b){
        if((object)a == null)
            return (object)b == null;
        return a.Equals(b);
    }
    public static bool operator!=(Foo a, Foo b){
        return !(a == b);
    }
