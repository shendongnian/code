    public class MyResultImageConverter : IValueConverter  
    {
        public Image OkImage { get; set; }
        public Image FailImage { get; set; }
        public string OkImagePath { get; set{
             OkImage = new Image();
             OkImage.Source(value);
            }
        }
        public string FailImagePath { get; set{
             FailImage = new Image();
             FailImage.Source(value);
            }
        }
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value == null || !(value is MyCustomObject))
        {
            return null;
        }
        Image img = null;
        MyCustomObjectdbr = (MyCustomObject)value;
        switch (MyCustomObjectdbr.Code)
        {
            case (int)MyEnum.OK:
                img = this.OkImage;
                break;
            case (int)MyEnum.NOK:
                img  = this.FailImage;
                break;
            default:
                break;
        }
        return img;
    }
    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
    }
