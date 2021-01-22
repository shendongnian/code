    public MyForm()
    {
        InitializeComponent();
        //Create a BindingSource, set its DataSource to my list,
        //set the DataGrid's DataSource to the BindindingSource...
        _bindingSource.AddingNew += OnAddingNewToBindingSource;
    }
    private void OnAddingNewToBindingSource(object sender, AddingNewEventArgs e)
    {
        if(dataGridView1.Rows.Count == _bindingSource.Count)
        {
            _bindingSource.RemoveAt(_bindingSource.Count - 1);
        }
    }
