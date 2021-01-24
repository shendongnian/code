    async IAsyncEnumerable<int> GetBigResultsAsync()
    {
        await foreach (var result in GetResultsAsync())
        {
            if (result > 20) yield return result; 
        }
    }
	IAsyncEnumerable<string> GetAsyncAnswers()
	{
		return AsyncEnum.Enumerate<string>(async consumer =>
		{
			foreach (var question in GetQuestions())
			{
				string theAnswer = await answeringService.GetAnswer(question);
				await consumer.YieldAsync(theAnswer);
			}
		});
	}
