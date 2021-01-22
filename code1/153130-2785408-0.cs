    public static class FireAndForgetMethods
    {
        public static void FireAndForget<T>(this Action<T> act,T arg1)
        {
            var tsk = Task.Factory.StartNew( ()=> act(arg1), TaskCreationOptions.LongRunning);
            tsk.ContinueWith(cnt => cnt.Dispose());
        }
    }
