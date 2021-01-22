    namespace Wpf
    {
      public static class DialogCloser
      {
        public static readonly DependencyProperty DialogResultProperty =
            DependencyProperty.RegisterAttached(
                "DialogResult",
                typeof(bool?),
                typeof(DialogCloser),
                new PropertyMetadata(DialogResultChanged));
        private static void DialogResultChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
          var window = d.GetWindow();
          if (window != null)
            window.DialogResult = e.NewValue as bool?;
        }
        public static void SetDialogResult(DependencyObject target, bool? value)
        {
          target.SetValue(DialogResultProperty, value);
        }
      }
      public static class Extensions
      {
        public static Window GetWindow(this DependencyObject sender_)
        {
          Window window = sender_ as Window;        
          return window ?? Window.GetWindow( sender_ );
        }
      }
    }
