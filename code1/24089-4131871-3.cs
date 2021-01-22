    static void Main(string[] args)
    {
        int a = 123;
        int? b = null;
        object c = new object();
        object d = null;
        int? e = 456;
        var f = (int?)789;
        bool result1 = ValueTypeHelper.IsNullable(a); // false
        bool result2 = ValueTypeHelper.IsNullable(b); // true
        bool result3 = ValueTypeHelper.IsNullable(c); // false
        bool result4 = ValueTypeHelper.IsNullable(d); // false
        bool result5 = ValueTypeHelper.IsNullable(e); // true
        bool result6 = ValueTypeHelper.IsNullable(f); // true
    
