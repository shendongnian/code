    public class WindowService : IWindowService
    {
        public void CreateWindow(SomeViewModel vm)
        {
            Window win = new Window();
            win.DataContext = vm;
            win.Show();
        }
    }
