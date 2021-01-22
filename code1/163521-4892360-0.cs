        public interface ICanExecuteChanged : ICommand
        {
            void RaiseCanExecuteChanged();
        }
        public static class BoundCommand
        {
            public static object GetParameter(DependencyObject obj)
            {
                return (object)obj.GetValue(ParameterProperty);
            }
            public static void SetParameter(DependencyObject obj, object value)
            {
                obj.SetValue(ParameterProperty, value);
            }
            public static readonly DependencyProperty ParameterProperty = DependencyProperty.RegisterAttached("Parameter", typeof(object), typeof(BoundCommand), new UIPropertyMetadata(null, ParameterChanged));
            private static void ParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var button = d as ButtonBase;
                if (button == null)
                {
                    return;
                }
                button.CommandParameter = e.NewValue;
                var cmd = button.Command as ICanExecuteChanged;
                if (cmd != null)
                {
                    cmd.RaiseCanExecuteChanged();
                }
            }
        }
