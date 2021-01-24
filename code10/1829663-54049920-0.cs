    string file= @"fakepath\abc.xlsx";
    
    DataSet result = new DataSet();
    
    //------To read the xlsx file
    if (file.EndsWith(".xlsx"))
    {
        // Reading from a binary Excel file (format; *.xlsx)
        using (FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read))
        {
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            result = excelReader.AsDataSet();
            excelReader.Close();
        }
    }
    
    //-------To convert the file into csv format
    var a = new StringBuilder();
    int columnCount=result.Tables[0].Columns.Count;
    foreach (DataRow dataRow in result.Tables[0].Rows)
    {
        var values=new List<string>(columnCount);
        for (int i = 0; i < columnCount; i++)
        {
            values.Add(dataRow[i].ToString());
        }
        string line=string.Join(",", values.Select(v=>$"\"{Escape(v)}\"");
        a.AppendLine(line); // even neater than Environment.NewLine
    }
    
    string output = @"fakepath\abc.csv";
    using(StreamWriter csv = new StreamWriter(@output, false))
    {
        csv.Write(a.ToString());
    }
