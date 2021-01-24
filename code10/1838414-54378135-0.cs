    private ThreadLocal<int> _recursiveCounter = new ThreadLocal<int>(() => 0);
    public void MyMethod(int param)
    {
        _recursiveCounter.Value++;
        try
        {
            if(_recursiveCounter.Value > 2)
                Trace.WriteLine($"Recursive exceeds 2 with {_recursiveCounter.Value}");
            if(param == 0)
                return;
            MyMethod(param-1);
        }
        finally
        {
            _recursiveCounter.Value--;
        }
    }
