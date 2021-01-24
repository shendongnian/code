    public static bool IsForm = false;
     public override async Task DefaultMatchHandler(IDialogContext context, 
     string originalQueryText, QnAMakerResult result)
     {
         QnaAnswer a = result.Answers.First();
         var messageActivity = ProcessResultAndCreateMessageActivity(context, ref result);
         if (a.Answer == "form")
         {
		     IsForm = true;
		     var form = new FormDialog<JObject>(new JObject(), JsonForm.BuildJsonForm, FormOptions.PromptInStart);
		     context.Call(form, FormCallback);
         }
	     else
	     {
		      IsForm = false;
		      messageActivity.Text = $"{result.Answers.First().Answer}";
	     }
         if (IsForm == false)
	     {
		     await context.PostAsync(messageActivity);
		     context.Wait(MessageReceived);
	     }
     }
