    public class ToolTipEx : ToolTip
    {
        static ToolTipEx()
        {
            IsReallyOpenProperty =
                DependencyProperty.Register(
                    "IsReallyOpen",
                    typeof(bool),
                    typeof(ToolTipEx),
                    new FrameworkPropertyMetadata(
                        defaultValue: false,
                        flags: FrameworkPropertyMetadataOptions.None,
                        propertyChangedCallback: StaticOnIsReallyOpenedChanged));
        }
        public static readonly DependencyProperty IsReallyOpenProperty;
        protected static void StaticOnIsReallyOpenedChanged(
            DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ToolTipEx self = (ToolTipEx)o;
            self.OnIsReallyOpenedChanged((bool)e.OldValue, (bool)e.NewValue);
        }
        protected void OnIsReallyOpenedChanged(bool oldValue, bool newValue)
        {
            this.IsOpen = newValue;
        }
        public bool IsReallyOpen
        {
            get
            {
                bool b = (bool)this.GetValue(IsReallyOpenProperty);
                return b;
            }
            set { this.SetValue(IsReallyOpenProperty, value); }
        }
        protected override void OnClosed(RoutedEventArgs e)
        {
            System.Diagnostics.Debug.Print(String.Format(
                "OnClosed: IsReallyOpen: {0}, StaysOpen: {1}", this.IsReallyOpen, this.StaysOpen));
            if (this.IsReallyOpen && this.StaysOpen)
            {
                e.Handled = true;
                // We cannot set this.IsOpen directly here.  Instead, send an event asynchronously.
                // DispatcherPriority.Send is the highest priority possible.
                Dispatcher.CurrentDispatcher.BeginInvoke(
                    (Action)(() => this.IsOpen = true),
                    DispatcherPriority.Send);
            }
            else
            {
                base.OnClosed(e);
            }
        }
    }
