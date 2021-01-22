    // In public class Foo
    public bool IsStopping { get; private set; }
    void DoWork() {
        while (!IsStopping) {
            // Pass this foo instance to MoreWork here (or via DoMoreWork)
            MoreWork mw = new MoreWork(this);
            mw.DoMoreWork();
            // do work...
        }
    }
