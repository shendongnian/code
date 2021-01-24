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
            
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            var path = AssociatedObject.GetChildren<Path>().FirstOrDefault(e => e.Name.Equals("Path"));
            if (path != null)
                path.StrokeThickness = GetStrokeThickness(AssociatedObject);
        }
        public static void SetStrokeThickness(DependencyObject dependencyObject, double value)
        {
            dependencyObject.SetValue(StrokeThicknessProperty, value);
        }
    }
