    // call with one parameter (using the Action<T> delegate of the framework
    bool success = TimedMethodCaller(new Action<int>(TestMethod), 100, "text"); 
    // call with several parameters using custom delegate that is defined like this:
    // public delegate void SampleDelegate(string text, int numeric);
    bool success = TimedMethodCaller(new SampleDelegate(TestMethod), 100, "text", 1);
