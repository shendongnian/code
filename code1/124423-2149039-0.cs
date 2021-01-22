    using System.Threading;
    private void FunctionForNewThread()
    {
    //do stuff
    }
    private void FunctionWithParameter(object param)
    {
    //Should do checks with typeof() on param before casting
    int convertedparam = (int)param;
    //do stuff
    }
    Thread t, t2;
    static void Main()
    {
        ThreadStart ts = new ThreadStart(FunctionForNewThread);
        t = new Thread(ts);
        t.Start();
        int x = 5;
        ParameterizedThreadStart pts = new ParameterizedThreadStart(FunctionWithParameter);
        t2 = new Thread(pts);
        t2.Start(x);
    }
