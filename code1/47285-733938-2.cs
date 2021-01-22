    public static bool operator ==(MyDataClass a, MyDataClass b)
    {
        // If both are null, or both are same instance, return true.
        if (System.Object.ReferenceEquals(a, b))
        {
           return true;
        }
        // If one is null, but not both, return false.
        if (((object)a == null) || ((object)b == null))
        {
           return false;
        }
        // Otherwise use equals
        return a.Equals(b);
    }
    public override bool Equals(System.Object obj)
    {
        // If parameter is null return false.
        if (obj == null)
        {
            return false;
        }
        // If parameter cannot be cast to MyDataClass return false.
        MyDataClass p = obj as MyDataClass;
        if ((System.Object)p == null)
        {
            return false;
        }
        return (x == p.x);
    }
