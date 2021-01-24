private bool _running = false;
private readonly object _lock = new object();
void Method(int value)
{
    lock (_lock)
    {
        if (_running)
        {
            return;
        }
        else
        {
            _running = true;
        }
    }
    if (value == 0)
    {
        // Do some operations which may exceed one hour
    }
    else if (value == 1)
    {
        // Do some operation’s which may exceed one hour
    }
    _running = false;
}
