    this.myData = new DataGridView();
    ((System.ComponentModel.ISupportInitialize)(myData)).BeginInit();
    myData.Location = new System.Drawing.Point(12, 42);
    myData.Name = "myData";
    myData.Size = new System.Drawing.Size(1060, 585);
    myData.TabIndex = 32;
    foreach (XElement xElem in xInfoItems)
    {
        numItems++;
    }
            
    // Here we create a DataTable with two columns.
    DataTable table = new DataTable();
    table.Columns.Add("Key", typeof(string));
    table.Columns.Add("Value", typeof(string));
    foreach (XElement xElem in xInfoItems)
    {
         //Here we add rows to table
         table.Rows.Add(xElem.Attribute("key").Value, xElem.Value);
    }
    myData.DataSource = table;
    myData.Refresh();
    this.PerformLayout(); 
