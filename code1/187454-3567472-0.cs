    void DataDisplayView_Paint(object s, PaintEventArgs e)
    {
        DataDisplayView.Paint -= DataDisplayView_Paint;
        DoSomethingAsynchronously(); // re-hooks event handler when completed
    }
    void DoSomethingAsychronously()
    {
        ThreadPool.QueueUserWorkItem(() =>
        {
            try
            {
                // DOSOMETHING
            }
            finally
            {
                // may need a lock around this statement
                DataDisplayView.Paint += DataDisplayView_Paint;
            }
        });
    }
