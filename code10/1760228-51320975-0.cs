    ContentOverride.OverRideContent<WindowtobeHide>(userControl);
    public static class ContentOverride
    {
        public static void OverRideContent<T>(UserControl objMain)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(T))
                {                    
                    window.Content = objMain;
                    window.Activate();
                }
            }
        }
    }
