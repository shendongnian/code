    public static void DisposeIfPossible(this object o) {
        IDisposable disp = o as IDisposable;
        if (disp != null)
            disp.Dispose();
    }
    // ...
    someObject.DisposeIfPossible(); // extension method on object
