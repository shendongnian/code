    using System.Diagnostics;
    public string __Function() {
        StackTrace stackTrace = new StackTrace();
        return stackTrace.GetFrame(1).GetMethod().Name;
    }
