    public abstract class MyBaseControl : ContentControl
    {
        public MyBaseControl()
        {
            Loaded += MyBaseControl_Loaded;
        }
        private void MyBaseControl_Loaded(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Closing += ParentWindow_Closing;
            Loaded -= MyBaseControl_Loaded;
        }
        private void ParentWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //cleanup...
        }
    }
