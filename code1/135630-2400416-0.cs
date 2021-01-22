    // Let's create our Object That contains the data to show in our Grid first
    string[] myData = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
    // Create the Object
    GridView gv = new GridView();
    
    // Assign some properties
    gv.ID = "myGridID";
    gv.AutoGenerateColumns = true;
    
    // Assing Data (this can be a DataTable or you can create each column through Columns Colecction)
    gv.DataSource = myData;
    gv.DataBind();
    
    // Now that we have our Grid all set up, let's add it to our Place Holder Control
    ph.Controls.Add(gv);
