HttpListener listener;
HttpListenerTimeoutManager manager;
public Foo()
{
    manager = listener.TimeoutManager;
    manager.IdleConnection = TimeSpan.FromMinutes(5);
    manager.HeaderWait = TimeSpan.FromMinutes(5);
}
