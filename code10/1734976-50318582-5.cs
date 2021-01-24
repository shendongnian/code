    private void concelhos_datagrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        // Your code...
        var editForm = new Concelhos_Edit();
        var editFormModel = new Info();
        editFormModel.Id = f.txt_id.Text = concelhos_datagrid.CurrentRow.Cells[0].Value.ToString();
        // Set other properties
 
        // Here is the work for dropdown
        var _nomeContrato = ContratosTable.AsEnumerable().FirstOrDefault(a => a.Field<int>("IdContrato") == ((DataRowView)bs.Current).Row.Field<int>("IdContrato")).Field<string>("Designacao");
            
        editFormModel.NomeContrato.AddRange(_nomeContrato);
        
        formEdit.Model = editFormModel;
        formEdit.MdiParent = this.MdiParent;
        formEdit.Show();
    }
