    public static class SynchronizedInvoker
    {
        public static void Invoke(Action action)
        {
            Form form = Application.OpenForms.Cast<Form>().FirstOrDefault();
            if (form != null && form.InvokeRequired)
                form.Invoke(action);
            else
                action();
        }
    }
