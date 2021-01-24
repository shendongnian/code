    public Form1()
    {
     InitializeComponent();
     // load the file
     DataSet ds = new DataSet();
     ds.ReadXml("sample.xml");
     // Removed usage of BindingSource
     // BindingSource bs = new BindingSource();
     // bs.DataSource = ds.Tables[0];
     textBox1.DataBindings.Add("Text", ds.Tables[0], "SubNode1");
     comboBox1.DataBindings.Add("SelectedIndex", ds.Tables[0], "SubNode2");
     checkBox1.DataBindings.Add("Checked", ds.Tables[0], "SubNode3");
     // Error fixed when using ds directly
     textBox2.DataBindings.Add("Text", ds.Tables[1], "SecondNode1");
     comboBox2.DataBindings.Add("SelectedIndex", ds.Tables[1], "SecondNode2");
     checkBox2.DataBindings.Add("Checked", ds.Tables[1], "SecondNode3");
    }
