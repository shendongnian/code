    enum SomeWierdReturn
    { Both = 0, None = 1, Active = 2, Inactive = 4 }
    public SomeWierdReturn DoSomething(SomeWierdReturn flag1, SomeWierdReturn flag2, SomeWierdReturn flag3)
    {
        return (SomeWierdReturn)(flag1 & flag2 & flag3);
    }
