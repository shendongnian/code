    public class ComboBoxFixer : DependencyObject
    {
      static DependencyPropertySynchronizer sync =
        new DependencyPropertySynchronizer
        {
          Priority = DispatcherPriority.ApplicationIdle
        };
 
      public static readonly DependencyProperty InternalItemProperty =
       sync.RegisterAttached("InternalItem", typeof(object), typeof(ComboBoxFixer),
       new FrameworkPropertyMetadata
       {
         BindsTwoWayByDefault = true
       });
      public static readonly DependencyProperty SelectedItemProperty =
        sync.RegisterAttached("SelectedItem", typeof(object), typeof(ComboBoxFixer),
        new FrameworkPropertyMetadata
        {
          BindsTwoWayByDefault = true,
          PropertyChangedCallback = (obj, e) =>
          {
            BindingOperations.SetBinding(
              obj, InternalItemProperty, new Binding("SelectedItem"));
          }
        });
      public static object GetSelectedItem(...  // normal attached property stuff
      public static void SetSelectedItem(...
    }
