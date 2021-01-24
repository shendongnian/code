     public class CircularProgressBarBehavior : StyleBehavior<ProgressBar, CircularProgressBarBehavior>
    {
        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.RegisterAttached("StrokeThickness", typeof(double), typeof(CircularProgressBarBehavior), new PropertyMetadata(3d));
        public static double GetStrokeThickness(DependencyObject dependencyObject)
        {
            return (double) dependencyObject.GetValue(StrokeThicknessProperty);
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += AssociatedObjectOnLoaded;
        }
        private static void AssociatedObjectOnLoaded(object sender, RoutedEventArgs args)
        {
            if (sender is ProgressBar progressBar)
            {
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                var path = progressBar.GetChildren<Path>().FirstOrDefault(e => e.Name.Equals("Path") && e.StrokeThickness == 3);
                if (path != null)
                    path.StrokeThickness = GetStrokeThickness(progressBar);
            }
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Loaded -= AssociatedObjectOnLoaded;
        }
        public static void SetStrokeThickness(DependencyObject dependencyObject, double value)
        {
            dependencyObject.SetValue(StrokeThicknessProperty, value);
        }
    }
