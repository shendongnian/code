    formDlg.Dispose();
    Application.DoEvents();
    GC.Collect();
    GC.WaitForPendingFinalizers();   
    string sUserEntered = box.Text; // After parent Dispose'd!
