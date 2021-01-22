    XElement xe1 = XElement.Load(filePath);
    DataTable myTable = new DataTable();
    myTable = mkTable();   // calls a function that makes the table
    var _categories = (from p1 in xe1.Descendants("category") select p1);
    int numCat = _categories.Count();
    int i = 0;
    while (i < numCat)
    {
        DataRow newrow;
        newrow = myTable.NewRow();
        if (_categories.ElementAt(i).Parent.Name == "topic")
        {
            string att1 = _categories.ElementAt(i).Parent.Attribute("name").Value.ToString();
            newrow["topic"] = att1.ToString();
        }
        // repeat the above for the different things in my document
        myTable.Rows.Add(newrow);
        i++;
    }
    myDataSet.Merge(myTable);
    bindingSourceIn.DataSource = myDataSet;
    myDataGridView.DataSource = bindingSourceIn;
    myDataGridView.DataMember = "xmlthing";
