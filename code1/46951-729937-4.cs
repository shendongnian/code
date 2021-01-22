    void Method()
    {
        using (suspendLatch.GetToken())
        {
            // Update selected index etc
        }
    }
    void listbox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (suspendLatch.HasOutstandingTokens)
        {
            return;
        }
    
        // Do some work
    }
