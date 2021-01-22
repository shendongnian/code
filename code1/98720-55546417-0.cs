    public static class AppForms
    {
        public static int OpenForms { get; private set; }
        public static event EventHandler FormShown;
        public static event EventHandler FormClosed;
        public static void Watch(Form form)
        {
            form.Shown += (sender, e) => { OpenForms++; FormShown?.Invoke(sender, e); };
            form.Closed += (sender, e) => { OpenForms--; FormClosed?.Invoke(sender, e); };
        }
    }
