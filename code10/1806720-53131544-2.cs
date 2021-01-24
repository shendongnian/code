    private static int CompareProps(MyObject a, MyObject b)
    {
         var aValues = a.GetType().GetProperties().Select(x => x.GetValue(a, null));
         var bValues = b.GetType().GetProperties().Select(x => x.GetValue(b, null));
    
         return aValues.Intersect(bValues).Count();
    }
