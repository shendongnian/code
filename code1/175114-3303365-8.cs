    public void Command(B obj)
    {
        A<B> a = (A<B>)new Implementor();
        a.SetObject(obj);
    }
