    // put a syncContext instance somewhere you can reach it
    static SynchronizationContext syncContext = SynchronizationContext.Current ?? new System.Windows.Forms.WindowsFormsSynchronizationContext();
    
    // subscribe to workbook deactivate
    workbook.Deactivate += workbook_Deactivate;
    
    [DebuggerHidden]
    private void workbook_Deactivate()
    {
        // here, the workbook is still alive, but we can schedule
        // an action via the SyncContext which will execute 
        // right after the deactivate event is completed. At that 
        // point, the workbook instance (RCW) will no longer be usable
        // meaning that the workbook has been closed
    
        syncContext.Post(x =>
        {
            try
            {
                // will throw if workbook is gone
                workbook.Path.ToString();
            }
            catch
            {
                // handle workbook closed
            }
        }, null);
    }
