    void SaveInfo()
    {
    blnCanCloseForm = false;
    Vosol[] vs = getAdd2DBVosol();
    if (DGError.RowCount > 0)
    return;
    
    Thread myThread = new Thread(() =>
    {
    this.Invoke((MethodInvoker)delegate {
    	picLoad.Visible = true;
    	lblProcces.Text = "Saving ...";
    });
    int intError = setAdd2DBVsosol(vs);
    Action action = (() =>
    {
    	if (intError > 0)
    	{
    		objVosolError = objVosolError.Where(c => c != null).ToArray();
    		DGError.DataSource = objVosolError;// dtErrorDup.DefaultView;
    		DGError.Refresh();
    		DGError.Show();
    		lblMSG.Text = "Check Errors...";
    	}
    	else
    	{
    		MessageBox.Show("Saved All Records...");
    		blnCanCloseForm = true;
    		this.DialogResult = DialogResult.OK;
    		this.Close();
    	}
    
    });
    this.Invoke((MethodInvoker)delegate {
    	picLoad.Visible = false;
    	lblProcces.Text = "";
    });
    this.BeginInvoke(action);
    });
    myThread.Start();
    }
    
    void frmExcellImportInfo_FormClosing(object s, FormClosingEventArgs e)
    {
    	if (!blnCanCloseForm)
    		e.Cancel = true;
    }
