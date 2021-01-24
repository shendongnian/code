    public class HelperClass : DependencyObject {
        public static readonly DependencyProperty ActiveDepartmentProperty =
            DependencyProperty.Register( "ActiveDepartment", typeof( Department ),
            typeof( HelperClass ), new UIPropertyMetadata( "" ) );
        public Department ActiveDepartment {
            get { return (Department) GetValue( ActiveDepartmentProperty ); }
            set { SetValue( ActiveDepartmentProperty, value ); }
        }
    
        public static HelperClass Instance { get; private set; }
    
        static HelperClass() {
            Instance = new HelperClass();
        }
    }
