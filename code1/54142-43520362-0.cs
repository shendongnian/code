    namespace VLEva.Core.Controls
    {
        /// <summary></summary>
        public static class ButtonBehavior
        {
            /// <summary></summary>
            public static readonly DependencyProperty IgnoreDoubleClickProperty = DependencyProperty.RegisterAttached("IgnoreDoubleClick",
                                                                                                                      typeof(bool),
                                                                                                                      typeof(ButtonBehavior),
                                                                                                                      new UIPropertyMetadata(false, OnIgnoreDoubleClickChanged));
    
            /// <summary></summary>
            public static bool GetIgnoreDoubleClick(Button p_btnButton)
            {
                return (bool)p_btnButton.GetValue(IgnoreDoubleClickProperty);
            }
    
            /// <summary></summary>
            public static void SetIgnoreDoubleClick(Button p_btnButton, bool value)
            {
                p_btnButton.SetValue(IgnoreDoubleClickProperty, value);
            }
    
            static void OnIgnoreDoubleClickChanged(DependencyObject p_doDependencyObject, DependencyPropertyChangedEventArgs e)
            {
                Button btnButton = p_doDependencyObject as Button;
                if (btnButton == null)
                    return;
    
                if (e.NewValue is bool == false)
                    return;
    
                if ((bool)e.NewValue)
                    btnButton.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(btnButton_PreviewMouseLeftButtonDown);
                else
                    btnButton.PreviewMouseLeftButtonDown -= btnButton_PreviewMouseLeftButtonDown;
            }
    
            static void btnButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                if (e.ClickCount >= 2)
                    e.Handled = true;
            }
    
        }
    }
