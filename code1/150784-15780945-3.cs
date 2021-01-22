    public static UIElement CreateUIElement()
    {
        UIElement element = null;
        Application.Current.Dispatcher.Invoke(
           System.Windows.Threading.DispatcherPriority.Normal, new Action(
              delegate()
              {
                  element = new UIElement();
                  // Initialize your UIElement here
              }));
        return element;
    }
