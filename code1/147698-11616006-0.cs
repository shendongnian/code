     public static readonly DependencyProperty IsExpandedProperty = 
            DependencyProperty.Register("IsExpanded", typeof(bool), typeof(Dock), 
            new FrameworkPropertyMetadata(true, OnIsExpandedChanged) { BindsTwoWayByDefault = true });
        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }
