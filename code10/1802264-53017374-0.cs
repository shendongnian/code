	// Define your NotUnderstood template
	[Serializable, Template(TemplateUsage.NotUnderstood, NOT_UNDERSTOOD)]
	public class MainReq
	{
		public const string NOT_UNDERSTOOD = "Not-understood message";
		[Prompt("Indicare la tipologia della richiesta? {||}")]
		public MainOptions? MainOption;
		public static IForm<MainReq> BuildForm()
		{
			var form = (new FormBuilder<MainReq>()
				.Prompter(PromptAsync)	// Build your form with a custom prompter
				.Build());
			return form;
		}
		private static async Task<FormPrompt> PromptAsync(IDialogContext context, FormPrompt prompt, MainReq state, IField<MainReq> field)
		{
			var preamble = context.MakeMessage();
			var promptMessage = context.MakeMessage();
			if (prompt.GenerateMessages(preamble, promptMessage))
			{
				await context.PostAsync(preamble);
			}
			// Here is where we've made a change to the default prompter.
			if (promptMessage.Text == NOT_UNDERSTOOD)
			{
				// Access the message the user typed with context.Activity
				await context.PostAsync($"Do what you want with the message: {context.Activity.AsMessageActivity()?.Text}");
			}
			else
			{
				await context.PostAsync(promptMessage);
			}
			return prompt;
		}
	}
