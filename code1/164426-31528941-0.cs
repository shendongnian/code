    namespace ExtensionMethods
    {
        public static class ExtensionMethods
        {
            public static void InvokeAndClose(this Control self, MethodInvoker func)
            {
                IAsyncResult result = self.BeginInvoke(func);
                self.EndInvoke(result);
                result.AsyncWaitHandle.Close();
            }
        }
    }
