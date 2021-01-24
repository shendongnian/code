 lang-cs
Add(new NumberPrompt<int>("myNumberPrompt", async (pvc, ct) => pvc.Succeeded && pvc.Recognized.Value > 1 && pvc.Recognized.Value < 100); 
And then some waterfall steps that utilize that prompt:
 lang-cs
private async Task<DialogTurnResult> FirstStep(WaterfallStepContext stepContext, CancellationToken cancellationToken)
{
    return await stepContext.PromptAsync("myNumberPrompt", new PromptOptions { Prompt = MessageFactory.Text("Please pick a number between 1 and 100") }, cancellationToken);    
}
private async Task<DialogTurnResult> SecondStep(WaterfallStepContext stepContext, CancellationToken cancellationToken)
{
   // Get the result of the previous step which will be the value from the NumberPrompt<int>
   var chosenNumber = (int)stepContext.Result;
   // Store the value into the WaterfallStepContext's Values dictionary
   stepContext.Values["ChosenNumber"] = chosenNumber;
   await stepContext.Context.SendActivityAsync($"Ok, {chosenNumber}, got it.");
   // ... more code here, maybe prompt for other values, whatever ...
}
