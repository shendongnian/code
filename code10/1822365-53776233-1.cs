    private List<string> _data;
    public List<string> Data 
    {
        get { return _data; }
        set 
        {
            _data = value;
            
            // This code uses the DataSource property of the combobox
            // combobox1.DataSource = null;
            // combobox1.DataSource = value;
            // This code works directly with the Items collection of the combo
            combobox1.Items.Clear();
            foreach(string s in _data)
                combobox1.Items.Add(s);
        }
    }; 
    public Form 2()
    {
        InitializeComponent();
    }
    ...
