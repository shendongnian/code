    List<myType> myList = new List<myType>(someCapacity);
    .
    ...populate the list with query from database...
    .
----------
    DataGridTableStyle myDataGridTableStyle = new DatGridtTableStyle();
    DataGridTextBoxColumn colA = new DataGridTextBoxColumn();
    DataGridTextBoxColumn colB = new DataGridTextBoxColumn();
    DataGridTextBoxColumn colC = new DataGridTextBoxColumn();
    
    colA.MappingName = "FieldA";
    colA.HeaderText = "Field A";
    colA.Width = 50; // or whatever;
    
    colB.MappingName = "FieldB";
    .
    ... etc. (lather, rinse, repeat for each column I want)
    .
    
    myDataGridTableStyle.GridColumnStyles.Add(colA);
    myDataGridTableStyle.GridColumnStyles.Add(colB);
    myDataGridTableStyle.GridColumnStyles.Add(colC);
