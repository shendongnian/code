	var sendDefaultMessageAndWait = true;
	qnaMakerResults = tasks.FirstOrDefault(x => x.Result.ServiceCfg != null)?.Result;
	if (tasks.Count(x => x.Result.Answers?.Count > 0) > 0)
	{
		var maxValue = tasks.Max(x => x.Result.Answers[0].Score);
		qnaMakerResults = tasks.First(x => x.Result.Answers[0].Score == maxValue).Result;
		if (qnaMakerResults != null && qnaMakerResults.Answers != null && qnaMakerResults.Answers.Count > 0)
		{
			if (this.IsConfidentAnswer(qnaMakerResults))
			{
				await this.RespondFromQnAMakerResultAsync(context, message, qnaMakerResults);
				await this.DefaultWaitNextMessageAsync(context, message, qnaMakerResults);
			}
			else
			{
				feedbackRecord = new FeedbackRecord { UserId = message.From.Id, UserQuestion = message.Text };
				await this.QnAFeedbackStepAsync(context, qnaMakerResults);
			}
			sendDefaultMessageAndWait = false;
		}
	}
	if (sendDefaultMessageAndWait)
	{
		await context.PostAsync(qnaMakerResults.ServiceCfg.DefaultMessage);
		await this.DefaultWaitNextMessageAsync(context, message, qnaMakerResults);
	}
