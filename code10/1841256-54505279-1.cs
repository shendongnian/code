    public MainWindow()
    {
        InitializeComponent();
        HelperClass.Instance.DepartmentChanged += OnDepartmentChanged;
    }
    private void OnDepartmentChanged(Department newDepartment)
    {
        activeDepartmentTextBlock.Text = newDepartment.Name;
    }
