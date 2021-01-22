	DataSet ds = new DataSet();
	// more ds init...
	string[] row = new string[1];
	IDataObject t = Clipboard.GetDataObject();
	System.IO.StreamReader sr = 
            new System.IO.StreamReader((System.IO.MemoryStream)t.GetData("csv"));
	while (!(sr.Peek == -1)) {
		row[0] = sr.ReadLine;
		ds.Tables[0].Rows.Add(row);
	}
	myGridView.DataSource = ds.Tables[0];
   
