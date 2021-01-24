    // Location of the template files
    private const string TEMPLATE_FOLDER ="Templates";
    public void test_loadListBox()
    {
        /// Loads the listBox with the items in the template folder
        //Clear list at the start
        listBox.Items.Clear();
        //find and add files from the directory
        string[] files = Directory.GetFiles(TEMPLATE_FOLDER);
        foreach(string file in files)
        {
            listBox.Items.Add(file); // Shows folder as well
            //listBox.Items.Add(Path.GetFileNameWithoutExtension(file)); // shows only filename
        }
    }
    public void LoadExcelTemplate(string locationString)
    {
        /// Import excel data to the datagrid.
        String sheetname = "Blad1";
        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                        locationString +
                        ";Extended Properties = \"Excel 12.0 Xml;HDR=YES\"; ";
        OleDbConnection con = new OleDbConnection(constr);
        OleDbCommand cmd = new OleDbCommand("Select * From [" + sheetname + "$]", con);
        OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
        DataTable data = new DataTable();
        sda.Fill(data);
        dataGrid.DataSource = data;
    }
    private void listBox_DoubleClick(object sender, EventArgs e)
    {
        /// Double clicking an object in the list
        if (listBox.SelectedItem != null)
        {
            //MessageBox.Show(listBox.SelectedItem.ToString());
            Console.WriteLine("DEBUG: " + System.IO.Path.Combine(TEMPLATE_FOLDER ,listBox.SelectedItem.ToString()));
            LoadExcelTemplate(System.IO.Path.Combine(TEMPLATE_FOLDER ,listBox.SelectedItem.ToString())); 
        }
    }
