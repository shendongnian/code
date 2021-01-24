csharp
private async Task<DialogTurnResult> DisplayCardAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
{
    // Create the Adaptive Card
    var cardPath = Path.Combine(".", "AdaptiveCard.json");
    var cardJson = File.ReadAllText(cardPath);
    var cardAttachment = new Attachment()
    {
        ContentType = "application/vnd.microsoft.card.adaptive",
        Content = JsonConvert.DeserializeObject(cardJson),
    };
    // Create the text prompt
    var opts = new PromptOptions
    {
        Prompt = new Activity
        {
            Attachments = new List<Attachment>() { cardAttachment },
            Type = ActivityTypes.Message,
            Text = "waiting for user input...", // You can comment this out if you don't want to display any text. Still works.
        }
    };
    // Display a Text Prompt and wait for input
    return await stepContext.PromptAsync(nameof(TextPrompt), opts);
}
private async Task<DialogTurnResult> HandleResponseAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
{
    // Do something with step.result
    // Adaptive Card submissions are objects, so you likely need to JObject.Parse(step.result)
    await stepContext.Context.SendActivityAsync($"INPUT: {stepContext.Result}");
    return await stepContext.NextAsync();
}
  [1]: https://i.stack.imgur.com/ntHlJ.png
  [2]: https://docs.microsoft.com/en-us/azure/bot-service/bot-builder-concept-dialog?view=azure-bot-service-4.0#waterfall-dialogs
In your main bot class (`<your-bot>.cs`) (step 3):
csharp
var activity = turnContext.Activity;
if (string.IsNullOrWhiteSpace(activity.Text) && !string.IsNullOrWhiteSpace(activity.Value))
{
	activity.Text = JsonConvert.SerializeObject(activity.Value);
}
