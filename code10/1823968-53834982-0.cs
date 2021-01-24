    public class CustomDatePicker:DatePicker
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
    
            if (Template.FindName("PART_Button", this) is Button button)
            {
                button.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    } 
