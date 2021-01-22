    public class MyClassOrStringComparer
    {
         public int Compare( object a, object b )
         {
             if (object.Equals(a,b))
             {
                 return 0;
             }
             else if (a == null)
             {
                 return -1;
             }
             else if (b == null)
             {
                 return 1;
             }
             string aName = null;
             string bName = null;
             if (a is string)
             {
                 aName = a;
             }
             else
             {
                 aName = ((MyClass)a).Name;
             }
             if (b is string)
             {
                 bName = b;
             }
             else
             {
                 bName = ((MyClass)b).Name;
             }
             return aName.CompareTo( b.Name );
       }
