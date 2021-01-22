    public Form1()
    {
        InitializeComponent();
        DataSet set1 = new DataSet();
        // Some xml data to populate the DataSet with.
        string testXml =
        "<?xml version='1.0' encoding='UTF-8'?>" +
        "<numbers>" +
        "<number><name>one</name></number>" +
        "<number><name>two</name></number>" +
        "<number><name>Two</name></number>" +
        "<number><name>three</name></number>" +
        "</numbers>";
        // Read the xml.
        StringReader reader = new StringReader(testXml);
        set1.ReadXml(reader);
        // Get a DataView of the table contained in the dataset.
        DataTableCollection tables = set1.Tables;
        // Set the CaseSensetive property
        tables[0].CaseSensitive = true;
        DataView view1 = new DataView(tables[0]);
            
        // Create a DataGridView control and add it to the form.            
        dataGridView1.AutoGenerateColumns = true;            
        // Create a BindingSource and set its DataSource property to
        // the DataView.
        BindingSource source1 = new BindingSource();
        source1.DataSource = view1;
        // Set the data source for the DataGridView.
        dataGridView1.DataSource = source1;
        // Set the Position property to the results of the Find method.
        int itemFound = source1.Find("name", "Two");
        source1.Position = itemFound;
    }
