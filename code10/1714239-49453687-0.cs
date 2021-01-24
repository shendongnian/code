    void ProcessMyFiles(string folderName)
    {
    	List<MyData> d = new List<MyData>();
    	var files = Directory.GetFiles(folderName);
    	foreach (var file in files)
    	{
    		OpenAndParse(file, d);
    	}
    
    	string[] headers = GetHeaders(files[0]);
    	DataGridView dgv = new DataGridView {Dock=DockStyle.Fill};
    	dgv.DataSource = d;
    	dgv.ColumnAdded += (sender, e) => {e.Column.HeaderText = headers[e.Column.Index];};
    
    	Form f = new Form();
    	f.Controls.Add(dgv);
    	f.Show();
    }
    
    string[] GetHeaders(string filename)
    {
    	var lines = File.ReadAllLines(filename);
    	var parsed = lines.Select(l => l.Split(';')).ToArray();
    	return new string[] { parsed[0][0], parsed[1][0], parsed[2][0], parsed[1][0] };
    }
    
    void OpenAndParse(string filename, List<MyData> d)
    {
    	var lines = File.ReadAllLines(filename);
    	var parsed = lines.Select(l => l.Split(';')).ToArray();
    	var data = new MyData
    	{
    		Col1 = parsed[0][1],
    		Col2 = parsed[1][1],
    		Col3 = parsed[2][1],
    		Col4 = parsed[1][2]
    	};
    	d.Add(data);
    }
    
    public class MyData
    {
    	public string Col1 { get; set; }
    	public string Col2 { get; set; }
    	public string Col3 { get; set; }
    	public string Col4 { get; set; }
    }
