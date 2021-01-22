    enum SomeWierdReturn
    { None = 1, Active = 2, Both1 = 3, Inactive = 4, Both2 = 5, Both3 = 6, Both4 = 7 }
    public SomeWierdReturn DoSomething(SomeWierdReturn flag1, SomeWierdReturn flag2, SomeWierdReturn flag3)
    {
        return ((int)flag1 | (int)flag2 | (int)flag3);
    }
