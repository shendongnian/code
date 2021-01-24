    public override async Task DefaultMatchHandler(IDialogContext context, string originalQueryText, QnAMakerResult result)
    {
        if (result.Answers.Length > 0 && result.Answers.FirstOrDefault().Score > 0.75 && flag)
        {
            await context.PostAsync(result.Answers.FirstOrDefault().Answer);
            await context.PostAsync("To continue using the FAQ please type another question, if not type no");
        }
        else if (originalQueryText.Contains("no"))
        {
            context.Done(true);
        }
        else
        {
            //detect if originalQueryText contains "faq"
            if (!originalQueryText.ToLower().Contains("faq"))
            {
                await base.DefaultMatchHandler(context, originalQueryText, result);
            }
            flag = true;
        }
    }
