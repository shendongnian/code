    void Main()
    {
    		ShowTablesFromXml(@"d:\temp\myxml.xml");
    }
    
    public void ShowTablesFromXml(string XmlFile)
    {
    		DataSet ds = new DataSet();
    		ds.ReadXml(XmlFile);
    		foreach (DataTable t in ds.Tables)
    		{
    			ShowData(t);
    		}
    		
    }
    
    public void ShowData(DataTable t)
    {
    	Form f = new Form();
    	f.Controls.Add(new DataGridView { Dock = DockStyle.Fill, DataSource=t });
    	f.Show();
    }
