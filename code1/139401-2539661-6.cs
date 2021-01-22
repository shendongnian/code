    public class ComboBoxFixer : DependencyObject
    {
      static DependencyPropertySynchronizer sync =
        new DependencyPropertySynchronizer
        {
          Priority = DispatcherPriority.ApplicationIdle,
          AutoSyncProperty = Selector.SelectedItemProperty,
        };
 
      public static readonly DependencyProperty SelectedItemProperty =
        sync.RegisterAttached("SelectedItem", typeof(object), typeof(ComboBoxFixer),
        new FrameworkPropertyMetadata
        {
          BindsTwoWayByDefault = true,
        });
      public static object GetSelectedItem(...  // normal attached property stuff
      public static void SetSelectedItem(...
    }
