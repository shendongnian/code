	public static IForm<MyClass> BuildForm()
	{
		var formBuilder = new FormBuilder<MyClass>()
			.Prompter(PromptAsync)
			;
		return formBuilder.Build();
	}
	/// <summary>
	/// Here is the method we're using for the PromptAsyncDelgate.
	/// </summary>
	private static async Task<FormPrompt> PromptAsync(IDialogContext context,
        FormPrompt prompt, MyClass state, IField<MyClass> field)
	{
		var preamble = context.MakeMessage();
		var promptMessage = context.MakeMessage();
		
		// Check to see if the form is on the confirmation step
		if (field.Name.StartsWith("confirmation"))
		{
			// If it's on the confirmation step,
			// we want to remove the MiddleName line from the text
			var lines = prompt.Prompt.Split('\n').ToList();
			var middleNameField = field.Form.Fields.Field(nameof(MiddleName));
			var format = new Prompter<MyClass>(
                middleNameField.Template(TemplateUsage.StatusFormat), field.Form, null);
			var middleNameLine = "* " + format.Prompt(state, middleNameField).Prompt;
			lines.RemoveAll(line => line.StartsWith(middleNameLine));
			prompt.Prompt = string.Join("\n", lines);
		}
		if (prompt.GenerateMessages(preamble, promptMessage))
		{
			await context.PostAsync(preamble);
		}
		await context.PostAsync(promptMessage);
		return prompt;
	}
