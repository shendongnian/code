        private static void OnIsFocusedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var uie = (UIElement)d;
            if ((bool)e.NewValue)
            {
                uie.Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(() =>
                {
                    uie.Focus();
                }));
            }
        }
