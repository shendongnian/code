class ViewModelA
{
    public IViewModelB B {get; private set;}
    public ViewModelA(IViewModelB b)
    {
        B = b;
    }
    public bool CanGo
    {
        get { return B.MyBoolProperty; }
    }
    [Dependencies("B.MyBoolProperty")]
    public void Go()
    {
        //Does something here
    }
}
