    public void OnSomeEvent(object sender, EventArgs e)
    { 
        using (var counter = new PerformanceCounter(CATEGORY_NAME, COUNTER_NAME, false))
        {
            counter.Increment();
        }
    
        // do your stuff here...
    }
