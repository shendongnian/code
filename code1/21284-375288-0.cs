    [Flags]
    public enum Department : byte
    {
        None = 0x00,
        A = 0x01,
        B = 0x02,
        C = 0x04,
        D = 0x08
    } // end enum Department
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.studentIsInDeptACheckBox.DataContext = new DataObject { Department = Department.A };
        }
    }
    public class DataObject
    {
        public DataObject()
        {
        }
        public Department Department { get; set; }
    }
    public class DepartmentValueConverter : IValueConverter
    {
        
        public DepartmentValueConverter()
        {
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Department mask = (Department)parameter;
            Department target = (Department)value;
            bool convertedValue = ((mask & target) != 0);
            return convertedValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((bool?)value).GetValueOrDefault() == true)
            {
                return (Department)parameter;
            }
            return Department.None;
        }
    }
