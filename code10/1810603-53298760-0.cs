	public void TestAsycnAwait()
	{
		var task = handleSummaryOfWallets();//Just call the method which will return the Task<List<object>>.
		task.Wait();//Call Wait on the task. This will hold the execution until complete execution is done.
		var listOfBalances = task.Result;//Task is executed completely. Read the result.
	}
