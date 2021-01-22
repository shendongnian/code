    public interface IWindow
    {
        void Open();
    }
    public class Window : IWindow
    {
        public virtual void Open()
        {
            // Open the window
        }
    }
    public class LockableWindow : IWindow
    {
        private IWindow _wrappedWindow;
        public LockableWindow(IWindow wrappedWindow)
        {
            _wrappedWindow = wrappedWindow;
        }
        public virtual void Open()
        {
            // TODO Unlock window if necessary
            _wrappedWindow.open();
        }
    }
