    public class CalenderHelper : DependencyObject
    {
        public static readonly DependencyProperty IsBlackOutDisabledProperty =
            DependencyProperty.RegisterAttached("IsBlackOutDisabled", typeof(bool), typeof(CalenderHelper), new PropertyMetadata(false, OnIsBlackOutDisabledChanged));
        public static bool GetIsBlackOutDisabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsBlackOutDisabledProperty);
        }
        public static void SetIsBlackOutDisabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsBlackOutDisabledProperty, value);
        }
        private static void OnIsBlackOutDisabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CalendarDayButton dayButton = d as CalendarDayButton;
            if (dayButton.IsLoaded)
            {
                SetBlackout(dayButton, (bool)e.NewValue);
            }
            else
            {
                dayButton.Loaded += (s, ee) =>
                {
                    SetBlackout(dayButton, (bool)e.NewValue);
                };
            }
        }
        static void SetBlackout(CalendarDayButton dayButton, bool collapsed)
        {
            ControlTemplate template = dayButton.Template;
            Path blackoutPath = template.FindName("Blackout", dayButton) as Path;
            if (collapsed)
                blackoutPath.Visibility = System.Windows.Visibility.Collapsed;
            else
                blackoutPath.Visibility = System.Windows.Visibility.Visible;
        }
    }
