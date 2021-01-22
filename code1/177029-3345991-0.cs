    static class UiExtensions
    {
        public static void SafeInvoke(this Control control, MethodInvoker method)
        {
            if (control.InvokeRequired)
                control.Invoke(method);
            else
                method();
        }
    }
    this.SafeInvoke(() => { InsertStockPrices(value, company); });
