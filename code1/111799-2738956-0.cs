    public class DataGridAttachedBehaviors
    {
       #region DoubleClick
       public static DependencyProperty OnDoubleClickProperty = DependencyProperty.RegisterAttached(
           "OnDoubleClick",
           typeof(ICommand),
           typeof(DataGridAttachedBehaviors),
           new UIPropertyMetadata(DataGridAttachedBehaviors.OnDoubleClick));
       public static void SetOnDoubleClick(DependencyObject target, ICommand value)
       {
          target.SetValue(DataGridAttachedBehaviors.OnDoubleClickProperty, value);
       }
       private static void OnDoubleClick(DependencyObject target, DependencyPropertyChangedEventArgs e)
       {
          var element = target as Control;
          if (element == null)
          {
             throw new InvalidOperationException("This behavior can be attached to a Control item only.");
          }
 
          if ((e.NewValue != null) && (e.OldValue == null))
          {
             element.MouseDoubleClick += MouseDoubleClick;
          }
          else if ((e.NewValue == null) && (e.OldValue != null))
          {
             element.MouseDoubleClick -= MouseDoubleClick;
          }
       }
       private static void MouseDoubleClick(object sender, MouseButtonEventArgs e)
       {
          UIElement element = (UIElement)sender;
          ICommand command = (ICommand)element.GetValue(DataGridAttachedBehaviors.OnDoubleClickProperty);
          command.Execute(null);
       }
       #endregion DoubleClick
      #region SelectionChanged
      //removed
      #endregion
    }
