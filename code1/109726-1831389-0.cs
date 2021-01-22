        public static class ExtensionMethods
    {
    
       private static Action EmptyDelegate = delegate() { };
     
    
       public static void Refresh(this UIElement uiElement)
       {
          uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
       }
    }
    
    private void LoopingMethod()
    {
       for (int i = 0; i < 10; i++)
       {
          label1.Content = i.ToString();
          label1.Refresh();
          Thread.Sleep(500);
       }
    }
