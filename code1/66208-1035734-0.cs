    public bool TrySomething()
    {
        CancelEventArgs e = new CancelEventArgs(); 
        if (Event1 != null) Event1.Invoke(e);
        if (e.Cancel == false)
        {
            if (Event2 != null) Event2.Invoke(e);
        }
    }
