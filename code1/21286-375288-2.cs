    [Flags]
    public enum Department
    {
        None = 0,
        A = 1,
        B = 2,
        C = 4,
        D = 8
    }
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.DepartmentsPanel.DataContext = new DataObject
            {
                Department = Department.A | Department.C
            };
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
        private Department target;
        public DepartmentValueConverter()
        {
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Department mask = (Department)parameter;
            this.target = (Department)value;
            return ((mask & this.target) != 0);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            this.target ^= (Department)parameter;
            return this.target;
        }
    }
