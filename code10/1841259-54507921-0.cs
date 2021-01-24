    public class Department
    {
        public string Name { get; set; }
    }
    public class HelperClass
    {
        public static event PropertyChangedEventHandler StaticPropertyChanged;
        private static Department activeDepartment;
        public static Department ActiveDepartment
        {
            get => activeDepartment;
            set
            {
                activeDepartment = value;
                StaticPropertyChanged?.Invoke(null,
                    new PropertyChangedEventArgs(nameof(ActiveDepartment)));
            }
        }
    }
