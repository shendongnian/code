     public class DataBounRadioButton: RadioButton
        {
            protected override void OnChecked(System.Windows.RoutedEventArgs e) {
                
            }
    
            protected override void OnToggle()
            {
                this.IsChecked = true;
            }
        }
