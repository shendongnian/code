    public class DynamicSelectorContentControl : ContentControl
    {
        // Using a DependencyProperty as the backing store for ListenToProperties.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ListenToPropertiesProperty =
            DependencyProperty.Register("ListenToProperties", typeof(string),
                typeof(DynamicSelectorContentControl),
                new FrameworkPropertyMetadata(string.Empty));
        public DynamicSelectorContentControl()
        {
            this.DataContextChanged += DynamicSelectorContentControl_DataContextChanged;
        }
        public string ListenToProperties
        {
            get { return (string)GetValue(ListenToPropertiesProperty); }
            set { SetValue(ListenToPropertiesProperty, value); }
        }
        private void CheckForProperty(object sender, PropertyChangedEventArgs e)
        {
            if (ListenToProperties.Contains(e.PropertyName))
            {
                ClearSelector();
            }
        }
        private void ClearSelector()
        {
            var oldSelector = this.ContentTemplateSelector;
            if (oldSelector != null)
            {
                this.ContentTemplateSelector = null;
                this.ContentTemplateSelector = oldSelector;
            }
        }
        private void DynamicSelectorContentControl_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            var listOfProperties = ListenToProperties.Split(',').Select(s => s.Trim());
            var oldObservable = e.OldValue as INotifyPropertyChanged;
            if (oldObservable != null && listOfProperties.Any())
            {
                PropertyChangedEventManager.RemoveHandler(oldObservable, CheckForProperty, string.Empty);
            }
            var newObservable = e.NewValue as INotifyPropertyChanged;
            if (newObservable != null && listOfProperties.Any())
            {
                PropertyChangedEventManager.AddHandler(newObservable, CheckForProperty, string.Empty);
            }
            if (e.OldValue != null)
            {
                ClearSelector();
            }
        }
    }
