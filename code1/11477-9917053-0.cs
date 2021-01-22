    interface IEmployee
    {
        int EmployeeId {get;}
        string FirstName {get;}
        string LastName {get;}
    }
    interface IEmployeeRepository
    {
        void SaveEmployee(IEmployee employee);
        IEmployee GetEmployeeById(int employeeId);
        IEmployee[] Employees { get; }
    }
    interface IEmployeeView
    {
        event Action<IEmployee> OnEmployeeSaved;
    }
    interface IEmployeeController
    {
        IEmployeeView View {get;}
        IEmployeeRepository Repository {get;}
        IEmployee[] Employees {get;}        
    }
    partial class EmployeeView: UserControl, IEmployeeView
    {
        public EmployeeView()
        {
            InitComponent();
        }
    }
    class EmployeeController:IEmployeeController
    {
        private IEmployeeView view;
        private IEmployeeRepository repository;
        public EmployeeController(IEmployeeView view, IEmployeeRepository repository)
        {
            this.repository = repository;
            this.view = view;
            this.view.OnEmployeeSaved+=new Action<IEmployee>(view_OnEmployeeSaved);
        }
        void  view_OnEmployeeSaved(IEmployee employee)
        {
            repository.SaveEmployee(employee);
        }
        public IEmployeeView View 
        {
            get
            { 
                return view;
            }
        }
        public IEmployeeRepository Repository
        {
            get
            {
                return repository;
            }
        }
        public IEmployee[] Employees
        {
            get 
            {
                return repository.Employees;
            }
        }
    }
