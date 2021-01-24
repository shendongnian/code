    class Kontak
    {
    public virtual void GetSpeed(){}
    public void SomeMethod()
    {
        // if overridden, it will call that method
        // otherwise it will call this class's method
        GetSpeed(); 
    }
    }
