    public class CollapsibleRow : RowDefinition
    {
        public static readonly DependencyProperty CollapsedProperty;
        public bool Collapsed
        {
            get => (bool)GetValue(CollapsedProperty);
            set => SetValue(CollapsedProperty, value);
        }
        static CollapsibleRow()
        {
            CollapsedProperty = DependencyProperty.Register("Collapsed",
                typeof(bool), typeof(CollapsibleRow), new PropertyMetadata(false, OnCollapsedChanged));
            RowDefinition.HeightProperty.OverrideMetadata(typeof(CollapsibleRow),
                new FrameworkPropertyMetadata(new GridLength(1, GridUnitType.Star), null, CoerceHeight));
            RowDefinition.MinHeightProperty.OverrideMetadata(typeof(CollapsibleRow),
                new FrameworkPropertyMetadata(0.0, null, CoerceHeight));
            RowDefinition.MaxHeightProperty.OverrideMetadata(typeof(CollapsibleRow),
                new FrameworkPropertyMetadata(double.PositiveInfinity, null, CoerceHeight));
        }
        private static object CoerceHeight(DependencyObject d, object baseValue)
        {
            return (((CollapsibleRow)d).Collapsed) ? (baseValue is GridLength ? new GridLength(0) : 0.0 as object) : baseValue;
        }
        private static void OnCollapsedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(RowDefinition.HeightProperty);
            d.CoerceValue(RowDefinition.MinHeightProperty);
            d.CoerceValue(RowDefinition.MaxHeightProperty);
        }
    }
