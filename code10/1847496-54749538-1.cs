    public interface IWindowService
    {
        void ShowWindow();
    }
    public class WindowService : IWindowService
    {
        public void ShowWindow();
        {
            Window window = new Window()
            window.Show();
        }
    }
