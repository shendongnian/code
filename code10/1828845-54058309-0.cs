    public class CollapsibleRow : RowDefinition
    {
        #region Fields
        private GridLength cachedHeight;
        private double cachedMinHeight;
        #endregion
        #region Dependency Properties
        public static readonly DependencyProperty CollapsedProperty =
            DependencyProperty.Register("Collapsed", typeof(bool), typeof(CollapsibleRow), new PropertyMetadata(false, OnCollapsedChanged));
        private static void OnCollapsedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is CollapsibleRow row && e.NewValue is bool collapsed)
            {
                if(collapsed)
                {
                    if(row.MinHeight != 0)
                    {
                        row.cachedMinHeight = row.MinHeight;
                        row.MinHeight = 0;
                    }
                    row.cachedHeight = row.Height;
                }
                else if(row.cachedMinHeight != 0)
                {
                    row.MinHeight = row.cachedMinHeight;
                }
                row.Height = collapsed ? new GridLength(0) : row.cachedHeight;
            }
        }
        #endregion
        #region Properties
        public bool Collapsed
        {
            get => (bool)GetValue(CollapsedProperty);
            set => SetValue(CollapsedProperty, value);
        }
        #endregion
    }
