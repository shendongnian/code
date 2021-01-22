    public string MyText
    {
      get { return _myText; }
      set { _myText = value; OnPropertyChanged("MyText"); }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
	PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
    private void theTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
      _myText = theTextBox.Text;
      OnPropertyChanged("MyText");
    }
  }
    [ValueConversion(typeof(string), typeof(System.Windows.Visibility))]
    public class StringToVisibilityConverter : System.Windows.Data.IValueConverter
    {
      public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        System.Windows.Visibility vis;
        string stringVal = (string)value;
        vis = (stringVal.Length < 1) ? Visibility.Visible : Visibility.Hidden;
        return vis;
      }
      public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        return null;
      }  
    }
    In the XAML:
    <TextBlock Background="AliceBlue" >
      <TextBlock.Visibility>
        <Binding ElementName="window1" Path="MyText" Converter="{StaticResource stringToVisibilityConverter}"/>
      </TextBlock.Visibility>
    </TextBlock>
  
