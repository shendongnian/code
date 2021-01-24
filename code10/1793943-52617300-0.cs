    using (var context = new TestResultsContext())
    {
        context.TestRuns.AddRange(_testRuns);
        context.SaveChanges();
    }
