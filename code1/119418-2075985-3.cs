    private void btnSaveAndClose_Click(object sender, EventArgs e)
    {
         if(IsDirty)
            If(Save(true))
                Close();
    }
