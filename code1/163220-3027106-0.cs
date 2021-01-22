    public class ComboBoxHelper : DependencyObject
    {
      public static int GetMaxDropDownItems(DependencyObject obj) { return (int)obj.GetValue(MaxDropDownItemsProperty); }
      public static void SetMaxDropDownItems(DependencyObject obj, int value) { obj.SetValue(MaxDropDownItemsProperty, value); }
      public static readonly DependencyProperty MaxDropDownItemsProperty = DependencyProperty.RegisterAttached("MaxDropDownItems", typeof(int), typeof(ComboBoxHelper), new PropertyMetadata
      {
        PropertyChangedCallback = (obj, e) =>
        {
          var box = (ComboBox)obj;
          box.DropDownOpened += UpdateHeight;
          if(box.IsDropDownOpen) UpdateHeight(box, null);
        }
      });
      private static void UpdateHeight(object sender, EventArgs e)
      {
        var box = (ComboBox)sender;
        box.Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(() =>
          {
            var container = box.ItemContainerGenerator.ContainerFromIndex(0) as UIElement;
            if(container!=null && container.RenderSize.Height>0)
              box.MaxDropDownHeight = container.RenderSize.Height * GetMaxDropDownItems(box);
          }));
      }
    }
