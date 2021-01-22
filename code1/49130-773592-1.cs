    [Test]
    public void WorkflowExampleTest()
    {
        (using var transaction = new TransactionScope())
        {
            DataContext.SuppressConnectionDispose = true;
            Presenter.ProcessWorkflow();
        }
    }
