        private bool CheckDotNet2SP()
        {
            try
            {
                CheckImpl();
                return true;
            }
            catch (MissingMethodException)
            {
                return false;
            }
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void CheckImpl()
        {
            using (var wh = new ManualResetEvent(true))
                wh.WaitOne(1);
        }
