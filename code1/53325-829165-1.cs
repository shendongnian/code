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
        public IWindow wrappedWindow;
        public virtual void Open()
        {
            // TODO Unlock window if necessary
            wrappedWindow.open();
        }
    }
