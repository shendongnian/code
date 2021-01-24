    // Declare In Parent form (outside functions, in the head of class)
    public DataTable dt = new DataTable();  // create *public* datatable
    // Get data any way you like into datatable
    string cmdTextTC = "SELECT TOP 1000 ID, Name, Componet FROM TestTable; ";   
    DataSet ds;
    ds = DataAccessLayer.GetQueryResultsTC(cmdText);
    If ds.Tables.Count > 0 Then
        dt = ds.Tables(0)
    End If
    // Use it for datagrid
    this.DataGridViewComponents.datasource = dt;
    // Declare In Child form (outside functions, in the head of class)
    public MyParentForm ParentFrm;   // link to parent
    public Int32 ComponentID;        // selected component
    // When declaring child form in the parent, remember to set some relations
    MyChildForm ChildForm; // child form
    ChildForm.ParentFrm = this;     // create reference to parent
    ChildForm.ComponentID = ComponentsGridView.SelectedRows(O).Index;  // Set Selected ID
    // Use data in ChildForm
    DataRow dr = ParentFrm.dt.rows(ComponentID);
    this.NumericUpDownID.Value = System.Convert.ToInt32(dr("ID"));
    this.TextBoxName.Text = System.Convert.ToString(dr("Name"));
