     protected void Page_Load(object sender, EventArgs e)
            {
                JQGridColumn dynamicColumn = new JQGridColumn();
                dynamicColumn.DataField = "Freight";
                dynamicColumn.CssClass = "redColor";
    
                JQGrid1.Columns.Add(dynamicColumn);
            }
