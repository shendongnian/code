	public abstract class BaseWindow : Window
    {
        protected BaseWindow()
        {
            OnInitialize();
        }
        public abstract void OnInitialize();
    }
