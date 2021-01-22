protected override void OnStart(string[] args)
{
    Foo f = new Foo(args);
    f.MethodThatNeverExits();
}
private void MethodThatNeverExits()
{
    LongRunningInitialization();
    while (true)
    {
        Thread.Sleep(pollingInterval);
        DoSomeWork();
    }
}
