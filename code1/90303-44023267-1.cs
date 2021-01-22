    public class SliderProgressBarAttachedProperty : DependencyObject
    {
        public static readonly DependencyProperty ProgressValueProperty =
            DependencyProperty.RegisterAttached("ProgressValue", typeof(int), typeof(SliderProgressBarAttachedProperty), new PropertyMetadata(OnItemsChanged));
        public static int GetProgressValue(DependencyObject obj)
        {
            return (int)obj.GetValue(ProgressValueProperty);
        }
        public static void SetProgressValue(DependencyObject obj, int value)
        {
            obj.SetValue(ProgressValueProperty, value);
        }
        public static readonly DependencyProperty ProgressMaximumProperty =
            DependencyProperty.RegisterAttached("ProgressMaximum", typeof(int), typeof(SliderProgressBarAttachedProperty), new PropertyMetadata(OnItemsChanged));
        public static int GetProgressMaximum(DependencyObject obj)
        {
            return (int)obj.GetValue(ProgressMaximumProperty);
        }
        public static void SetProgressMaximum(DependencyObject obj, int value)
        {
            obj.SetValue(ProgressMaximumProperty, value);
        }
        private static void OnItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var slider = d as Slider;
            var progressValue = GetProgressValue(d);
            var progressMaximum = GetProgressMaximum(d);
            if (slider == null) return;
            var progressBar = slider.Template.FindName("TrackProgressBar",slider) as ProgressBar;
            if (progressBar == null) return;
            progressBar.Maximum = progressMaximum;
            progressBar.Value = progressValue;
        }
    }
