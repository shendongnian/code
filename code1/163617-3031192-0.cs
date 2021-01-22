    public class TreeViewCustomizer : DependencyObject
    {
      public static bool GetContextMenuOpened(DependencyObject obj) { return (bool)obj.GetValue(ContextMenuOpenedProperty); }
      public static void SetContextMenuOpened(DependencyObject obj, bool value) { obj.SetValue(ContextMenuOpenedProperty, value); }
      public static readonly DependencyProperty ContextMenuOpenedProperty = DependencyProperty.RegisterAttached("ContextMenuOpened", typeof(bool), typeof(TreeViewCustomizer));
    }
