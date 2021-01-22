    public static class UI
    {
        public static void PerformUIAction(Control form, Action action)
        {
            PerformUIAction(form, action, (string) null);
        }
        public static void PerformUIAction(
            Control form, Action action, string message)
        {
            PerformUIAction(form, action, () => message);
        }
        public static void PerformUIAction(
            Control form, Action action, Func<string> messageHandler)
        {
            var saveCursor = form.Cursor;
            form.Cursor = Cursors.WaitCursor;
            try
            {
                action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    messageHandler() ?? ex.Message, "Exception!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                Debug.WriteLine(ex.ToString(), "Exception");
                throw;
            }
            finally
            {
                form.Cursor = saveCursor;
            }
        }
    }
