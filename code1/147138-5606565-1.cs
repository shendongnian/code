    public Form1()
    {
        InitializeComponent();
        // This uses my CaseSensitiveBindingList which I have code for later
        BindingList<DGVItems> source = new CaseSensitiveBindingList<DGVItems>() 
            { 
                new DGVItems { Number = "one" },
                new DGVItems{Number = "two"},
                new DGVItems{Number = "Two"}
            };
            
        BindingSource bindingSource = new BindingSource();
        bindingSource.DataSource = source;
        dataGridView1.DataSource = bindingSource;
        var index = bindingSource.Find("Number", "Two");
        // Index is 2 (third item) as desired.
        MessageBox.Show(number.ToString());
            
    }
    public class DGVItems
    {
        public string Number { get; set; }
    }
