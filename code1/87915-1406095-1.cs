    public static void OneWay(Action action) {
        if (action == null) throw new ArgumentNullException("action");
        ThreadPool.QueueUserWorkItem(delegate {
            try { action(); }
            catch (Exception ex) {
                Trace.WriteLine(ex);
            }
        });
    }
    ...
    OneWay(() => DoSomeStuff("abc"));
