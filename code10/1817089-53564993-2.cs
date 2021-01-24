    List<string> addedTestNames = new List<string>();
    bool done = false;
    do
    {
        // MORE OPTIMIZED - OPTION 1
        addedTestNames.AddRange(cycle.ReturnListOfTestsWithinCycle().Select(e => e.Text).ToList());
        // LESS OPTIMIZED - OPTION 2
        //IList<IWebElement> displayedTests = cycle.ReturnListOfTestsWithinCycle();
        //for (int i = 0; i < displayedTests.Count; i++)
        //{
        //    addedTestNames.Add(displayedTests[i].Text);
        //}
        if (helper.DoesElementExist(driver, cycle.getScrollForwardArrowInResults()))
        {
            // click Next
        }
        else
        {
            done = true;
        }
    } while (!done);
