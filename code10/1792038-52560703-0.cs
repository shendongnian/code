    public static class AnimationEx
    {
        public static readonly DependencyProperty DynamicDurationProperty =
            DependencyProperty.RegisterAttached(
                "DynamicDuration", typeof(double), typeof(AnimationEx),
                new PropertyMetadata(DynamicDurationPropertyChanged));
        public static double GetDynamicDuration(DoubleAnimation animation)
        {
            return (double)animation.GetValue(DynamicDurationProperty);
        }
        public static void SetDynamicDuration(DoubleAnimation animation, double value)
        {
            animation.SetValue(DynamicDurationProperty, value);
        }
        private static void DynamicDurationPropertyChanged(
            DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var animation = o as DoubleAnimation;
            if (animation != null && animation.To.HasValue)
            {
                animation.Duration = TimeSpan.FromSeconds(
                    Math.Abs((double)e.NewValue - animation.To.Value) / 100);
            }
        }
    }
