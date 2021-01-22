    Excel.Application app = wbWorkbook.Application;
    string sWorkbookName = wbWorkbook.Name;
    Thread overseeWorkbooksThread = new Thread(new ThreadStart(
        delegate()
        {
            bool bOpened = false;
            Excel.Workbooks wbsWorkbooks = app.Workbooks;
            using (new DisposableCom<Excel.Workbooks>(wbsWorkbooks))
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    if (wbsWorkbooks.ContainsWorkbookProperly(sWorkbookName))
                        bOpened = true;
                    else
                        if (bOpened)
                            // Workbook was open, so it has been closed.
                            break;
                        else
                        {
                            // Workbook simply not finished opening, do nothing
                        }
                }
                // Workbook closed
                RunTheCodeToBeRunAfterWorkbookIsClosed();
            }
        }));
    overseeWorkbooksThread.Start();
