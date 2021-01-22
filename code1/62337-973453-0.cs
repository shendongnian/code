    public bool Equals(Foo pFoo)
    {
            if (pFoo == null)
                return false;
            return (pFoo.Id == Id);
    }
    public override bool Equals(object obj)
    {
            if (ReferenceEquals(obj, this))
                return true;
            return Equals(obj as Foo);
    }
