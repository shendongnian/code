    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        switch (keyData)
        {
            ...
            ...
            case Keys.Escape:
                {
                    if (mTreeView.LabelEdit)
                    {
                        mCanceledEdit = true;
                        mTreeView.EndEdit(true);
                        return true;
                    }
                    return false;
                }
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
    
    private void mTreeView_AfterLabelEdit(object sender, Crownwood.DotNetMagic.Controls.LabelEditEventArgs e)
    {
       if(mCanceledEdit == true)
       {
           e.Cancel = true;
           mAppData.MainForm.UpdateData();
           mCanceledEdit = false;
           return;
       }
       ...
       ...
    }
