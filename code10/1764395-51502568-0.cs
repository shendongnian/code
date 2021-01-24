    string[] ColArray = Regex.Split(columnarray, "\t\t");
    string[] DatArray = Regex.Split(dataArray, "\t\t");
    DatArray = DatArray.Where(x => !string.IsNullOrEmpty(x)).ToArray();
    
    //Join all the split string using (+)
    string datstring = string.Join("+", DatArray);
    //Remove the additional (+) symbol infront of the \r\n\ to match array length        
    datstring = Regex.Replace(datstring, @"[+\\r\\]\B", "");
    DataTable d = new DataTable();
          
    foreach (string b in ColArray{
        d.Columns.Add(b);                
        }
    // use a parser to parse through the string and add the items to your datatable
    using (var reader = new StringReader(datstring))
        {
            TextFieldParser parser = new TextFieldParser(reader)
            { HasFieldsEnclosedInQuotes = false, Delimiters = new string[] { "+" } };
            while(!parser.EndOfData)
            {
                var drow = d.NewRow();
                drow.ItemArray = parser.ReadFields();
                d.Rows.Add(drow);
            }
         }
    DGV.Datasource = d;
