    private void EventWritten(Object obj, EventRecordWrittenEventArgs arg)
    {
        PrintQueue myPrintQueue = new PrintQueue(ps, printer, PrintSystemDesiredAccess.AdministratePrinter);
        myPrintQueue.Pause();
        foreach (var job in myPrintQueue.GetPrintJobInfoCollection())
        {
            job.Pause();
        }
        Invoke((MethodInvoker) delegate {
             frmPromptPIN frm = new frmPromptPIN(printer);
             frm.Show();
        });
    }
