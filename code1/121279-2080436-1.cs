    public static bool operator ==(Foo<T> f1, Foo<T> f2)
    {
       if (object.ReferenceEquals(f1, f2))
       {
           return true;
       }
       if (object.ReferenceEquals(f1, null)) // f2=null is covered by Equals
       {
           return false;
       }
       return f1.Equals(f2);
    }
    
