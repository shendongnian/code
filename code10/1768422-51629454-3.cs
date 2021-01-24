    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Employee> listEmployees = new List<Employee>();
            listEmployees.Add(new Employee() { EmployeeName = "Bob" });
            listEmployees.Add(new Employee() { EmployeeName = "Mary" });
            listEmployees.Add(new Employee() { EmployeeName = "Kato" });
            listEmployees.Add(new Employee() { EmployeeName = "Mohammed" });
            dataEmployee.ItemsSource = listEmployees;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Employee currentEmployee = dataEmployee.SelectedItem as Employee;
            if (currentEmployee == null)
            {
                currentEmployeeName.Text = "no selection";
            }
            else
            {
                currentEmployeeName.Text = currentEmployee.EmployeeName;
            }
         }
    }
