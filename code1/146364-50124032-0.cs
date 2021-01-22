    myGridView.RowCreated += MyGridView_RowCreated;
    myGridView.DataSource = gridData;
    myGridView.DataBind();
    private void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
       Foreach (TableCell cell in e.Row.Cells)
       {
          BoundField field = (BoundField)((DataControlFieldCell)cell).ContainingField;
          field.HtmlEncode = false;
       }
    }
