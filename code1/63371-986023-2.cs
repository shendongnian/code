    public class ConnectWindow : GTK.Window
    {
        public ConnectWindow(Window parent)
            : base(WindowType.Toplevel)
        {
            this.Parent = parent;
            _init();
        }
        private void _init()
        {
            this.Title = "Connect to...";
            this.Modal = true;
            this.WindowPosition = WindowPosition.Center;
            this.KeyReleaseEvent += ConnectWindow_KeyReleaseEvent;
            // [snip] other initialisation stuff
        }
        void ConnectWindow_KeyReleaseEvent(object o, KeyReleaseEventArgs args)
        {
            if (args.Event.Key == Gdk.Key.Escape)
            {
                btnCancel.Activate();
            }
        }
    }
