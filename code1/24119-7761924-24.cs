        int a = 123;
        int? b = null;
        object c = new object();
        object d = null;
        int? e = 456;
        var f = (int?)789;
        string g = "something";
        bool isnullable = IsObjectNullable(a); // false 
        isnullable = IsObjectNullable(b); // true 
        isnullable = IsObjectNullable(c); // true 
        isnullable = IsObjectNullable(d); // true 
        isnullable = IsObjectNullable(e); // true 
        isnullable = IsObjectNullable(f); // true 
        isnullable = IsObjectNullable(g); // true
