     public bool CloseTrigger
            {
                get { return (bool)GetValue(CloseTriggerProperty); }
                set { SetValue(CloseTriggerProperty, value); }
            }
    
            public static readonly DependencyProperty CloseTriggerProperty =
                DependencyProperty.Register("CloseTrigger", typeof(bool), typeof(ControlEventBase), new PropertyMetadata(new PropertyChangedCallback(OnCloseTriggerChanged)));
    
            private static void OnCloseTriggerChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
            {
                //write Window Exit Code
            }
