    // In constructor
    AddDialog(new ChoicePrompt(choicePrompt));
    
    ...
    // In waterfall step
    var opts = new PromptOptions()
    {
        Prompt = MessageFactory.Text("What can i do for you?"),
        RetryPrompt = MessageFactory.Text("Sorry, please choose an option from the list."),
        Choices = new List<Choice>(),
    };
    
    opts.Choices.Add(new Choice() { Value = "Learn more!" });
    opts.Choices.Add(new Choice() { Value = "Opportunities!" });
    opts.Choices.Add(new Choice() { Value = "Define my goals!" });
    
    // Display a Choice Prompt and wait for input
    return await stepContext.PromptAsync("choicePrompt", opts);
