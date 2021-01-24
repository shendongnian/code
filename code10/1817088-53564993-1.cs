    List<string> addedTestNames = new List<string>();
    bool done = false;
    do
    {
        IList<IWebElement> displayedTests = cycle.ReturnListOfTestsWithinCycle();
        addedTestNames.AddRange(displayedTests.Select(e => e.Text).ToList());
        // I think the above line will work... but if not, the below lines should
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
