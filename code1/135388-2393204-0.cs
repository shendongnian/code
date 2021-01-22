    formDlg.Dispose();
    Application.DoEvents();
    GC.Collect();
    GC.WaitForPendingFinalizers();
    Application.DoEvents();    string sUserEntered = box.Text; // After parent Dispose'd!
