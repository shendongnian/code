    public static bool operator ==(Foo foo1, Foo foo2)
    {
        //  check if the left parameter is null
        bool LeftNull = false;
        try { Type temp = a_left.GetType(); }
        catch { LeftNull = true; }
        //  check if the right parameter is null
        bool RightNull = false;
        try { Type temp = a_right.GetType(); }
        catch { RightNull = true; }
        
        //  null checking results
        if (LeftNull && RightNull) return true;
        else if (LeftNull || RightNull) return false;
        else return foo1.field1 == foo2.field2;
    }
