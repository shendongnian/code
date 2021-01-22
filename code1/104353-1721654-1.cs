    protected void EntityGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var updatedEntity = new Entity {Fields = new List<string>()};
        var row = EntityGridView.Rows[e.RowIndex];
        
        var nameTextBox = (TextBox) row.FindControl("NameTextBox");
        updatedEntity.Name = nameTextBox.Text;
        
        var fieldListView = (ListView) row.FindControl("FieldListView");
        foreach (var dataItem in fieldListView.Items)
        {
            var fieldValueTextBox = (TextBox)dataItem.FindControl("FieldValue");
            updatedEntity.Fields.Add(fieldValueTextBox.Text);
        }
        // Do your save etc here
    }
