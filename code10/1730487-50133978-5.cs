    public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
    {
        var message = await argument;
            
        if (message != null && !string.IsNullOrEmpty(message.Text))
        {
            var tasks = this.services.Select(s => s.QueryServiceAsync(message.Text)).ToArray();
            await Task.WhenAll(tasks);
            if (tasks.Any())
            {
                var sendDefaultMessageAndWait = true;
                qnaMakerResults = tasks.FirstOrDefault(x => x.Result.ServiceCfg != null)?.Result;
                var qnaMakerFoundResults = tasks.Where(x => x.Result.Answers.Any()).ToList();
                if (qnaMakerFoundResults.Any())
                {
                    var maxValue = qnaMakerFoundResults.Max(x => x.Result.Answers[0].Score);
                    qnaMakerResults = qnaMakerFoundResults.First(x => x.Result.Answers[0].Score == maxValue).Result;
                    if (qnaMakerResults?.Answers != null && qnaMakerResults.Answers.Count > 0)
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
            }
        }
    }
