    void loadALoadOfStuff()
    {
        while(tabControlToClear.Controls.Count > 0)
            tabControlToClear.Controls[0].Dispose();
        //I even put in:
        GC.Collect();
        GC.WaitForPendingFinalizers();
        foreach(String pagename in globalList)
            tabControlToClear.Controls.Add(MakeATab(pagename));
    }
