    public static class Disposable
    {
        public static void SafelyDo<T>(this T disp, Action<T> action) where T : IDisposable
        {
            try
            {
                action(disp);
            }
            catch
            {
                disp.Dispose();
                throw;
            }
        }
    }
