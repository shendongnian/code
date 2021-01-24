    protected override async Task RespondFromQnAMakerResultAsync(IDialogContext context, IMessageActivity message, QnAMakerResults result)
    {
        // answer is a string
        var answer = result.Answers.First().Answer;
        Activity reply = ((Activity)context.Activity).CreateReply();
            
        var qnaAnswerData = answer.Split(';');
        var dataSize = qnaAnswerData.Length;
        if (dataSize == 3)
        {
            var title = qnaAnswerData[0];
            var description = qnaAnswerData[1];
            var url = qnaAnswerData[2];
            var imageUrl = qnaAnswerData[3];
            var card = new HeroCard
            {
                Title = title,
                Subtitle = description,
                Buttons = new List<CardAction>
                {
                    new CardAction(ActionTypes.OpenUrl, "Learn More", value: url)
                },
                Images = new List<CardImage>
                {
                    new CardImage(url = imageUrl)
                },
            };
            reply.Attachments.Add(card.ToAttachment());
        }
        else
        {
            reply.Text = answer;
        }
        await context.PostAsync(reply);
    }
    protected override async Task DefaultWaitNextMessageAsync(IDialogContext context, IMessageActivity message, QnAMakerResults result)
    {
        if (result.Answers.Count > 0)
        {
            // get the URL
            var answer = result.Answers.First().Answer;
            var qnaAnswerData = answer.Split(';');
            var dataSize = qnaAnswerData.Length;
            if (dataSize == 3)
            {
                var qnaUrl = qnaAnswerData[2];
                // pass user's question
                var userQuestion = (context.Activity as Activity).Text;
                context.Call(new FeedbackDialog(qnaUrl, userQuestion), ResumeAfterFeedback);
            }
            else
            {
                await ResumeAfterFeedback(context, new AwaitableFromItem<IMessageActivity>(null));
            }
        }
        else
        {
            await ResumeAfterFeedback(context, new AwaitableFromItem<IMessageActivity>(null));
        }
    }
    private async Task ResumeAfterFeedback(IDialogContext context, IAwaitable<IMessageActivity> result)
    {
        if (await result != null)
        {
            await MessageReceivedAsync(context, result);
        }
        else
        {
            context.Done<IMessageActivity>(null);
        }
    }
