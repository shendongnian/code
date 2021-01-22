class ViewModelA
{
    **public IViewModelB B {get; private set;}**
    public ViewModelA(IViewModelB b)
    {
        _b = b;
    }
    public bool CanGo
    {
        get { return _b.MyBoolProperty; }
    }
    **[Dependencies("B.MyBoolProperty")]**
    public void Go()
    {
        //Does something here
    }
}
