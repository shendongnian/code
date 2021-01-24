    /// <summary>
    /// Provide the ability to clip an UIElement to an ellipse.
    /// </summary>
    public static class EllipseClipper
    {
        /// <summary>
        /// The attached property of IsClipping.
        /// </summary>
        public static readonly DependencyProperty IsClippingProperty = DependencyProperty.RegisterAttached(
            "IsClipping", typeof(bool), typeof(EllipseClipper), new PropertyMetadata(false, OnIsClippingChanged));
        public static void SetIsClipping(DependencyObject element, bool value)
            => element.SetValue(IsClippingProperty, value);
        public static bool GetIsClipping(DependencyObject element)
            => (bool) element.GetValue(IsClippingProperty);
        private static void OnIsClippingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var source = (UIElement) d;
            if (e.NewValue is false)
            {
                // If IsClipping is set to false, clear the Clip property.
                source.ClearValue(UIElement.ClipProperty);
                return;
            }
            // If the Clip property is using for other usage, throw an exception.
            var ellipse = source.Clip as EllipseGeometry;
            if (source.Clip != null && ellipse == null)
            {
                throw new InvalidOperationException(
                    $"{typeof(EllipseClipper).FullName}.{IsClippingProperty.Name} " +
                    $"is using {source.GetType().FullName}.{UIElement.ClipProperty.Name} " +
                    "for clipping, dont use this property manually.");
            }
            // Use the clip property.
            ellipse = ellipse ?? new EllipseGeometry();
            source.Clip = ellipse;
            // Update the clip property by Bindings.
            var xBinding = new Binding(FrameworkElement.ActualWidthProperty.Name)
            {
                Source = source,
                Mode = BindingMode.OneWay,
                Converter = new HalfConverter(),
            };
            var yBinding = new Binding(FrameworkElement.ActualHeightProperty.Name)
            {
                Source = source,
                Mode = BindingMode.OneWay,
                Converter = new HalfConverter(),
            };
            var xyBinding = new MultiBinding
            {
                Converter = new SizeToClipCenterConverter(),
            };
            xyBinding.Bindings.Add(xBinding);
            xyBinding.Bindings.Add(yBinding);
            BindingOperations.SetBinding(ellipse, EllipseGeometry.RadiusXProperty, xBinding);
            BindingOperations.SetBinding(ellipse, EllipseGeometry.RadiusYProperty, yBinding);
            BindingOperations.SetBinding(ellipse, EllipseGeometry.CenterProperty, xyBinding);
        }
        /// <summary>
        /// Convert the size to ellipse center point.
        /// </summary>
        private sealed class SizeToClipCenterConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
                => new Point((double) values[0], (double) values[1]);
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
                => throw new NotSupportedException();
        }
        /// <summary>
        /// Calculate half of a double so that RadiusX and RadiusY can be calculated correctly.
        /// </summary>
        private sealed class HalfConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                => (double) value / 2;
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                => throw new NotSupportedException();
        }
    }
