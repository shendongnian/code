    public static class ExtensionMethods
    {
       private static Action EmptyDelegate = delegate() { };
     
       public static void Refresh(this UIElement uiElement)
       {
          uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
       }
    }
    void Page_Loaded(object sender, RoutedEventArgs e)
    {
        // irrelevant code
        foreach (// iterate over content that is added to each tab)
        {
            TabItem tabItem = new TabItem();
            // load content
            tabPanel.Items.Add(tabItem);
            tabItem.IsSelected = true;
            tabItem.Refresh();
        }
        // tabPanel.SelectedIndex = 0;
    }
