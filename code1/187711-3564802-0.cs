  public class ExtendedComboBox : ComboBox
    {
        public ExtendedComboBox()
        {
            this.IsEditable = true;
            this.LostFocus += ComboBox_LostFocus;
        }
        public string SelectedText
        {
            get
            {
                return (string)GetValue(SelectedTextProperty);
            }
            set
            {
                SetValue(SelectedTextProperty, value);
            }
        }
        public static readonly DependencyProperty SelectedTextProperty = DependencyProperty.Register("SelectedText", typeof(string), typeof(ExtendedComboBox), new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(OnSelectedTextPropertyChanged)));
       
        private static void OnSelectedTextPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }
        private void ComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            SelectedText = (e.Source as ComboBox).Text??string.Empty;
        }
    }
   // Binding Example
 %gt%local:ExtendedComboBox Margin="3" x:Name="ecb" SelectedText="{Binding SelectedText,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" ItemsSource="{Binding SelectedTextList}">%gt/local:ExtendedComboBox>
