    public Foo GetLowestLevelFoo(Foo foo)
        {
            if (foo.ChildFoo != null)
            {
                return GetLowestLevelFoo(foo.ChildFoo);
            }
            else
            {
                return foo;
            }
        }
