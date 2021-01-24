	[Serializable]
	public class FAQConversation
	{
		public string Inquiry { get; set; }
		private string LastMessage { get; set; }
		private const string TRY_AGAIN = "Try again";
		public static IForm<FAQConversation> BuildForm()
		{
			return new FormBuilder<FAQConversation>()
				// This is an alternative way of using the Field() method but it works the same.
				.Field(nameof(Inquiry),
					"Okay, tell me what is your question. Enter \"back\" to go back to Products Selection.",
					validate: AnswerInquiryAsync)
				.Prompter(PromptAsync)
				.Build();
		}
		private static async Task<ValidateResult> AnswerInquiryAsync(FAQConversation state, object value)
		{
			var result = new ValidateResult();
			bool testCase = Equals(value, "true");	// Enter "true" to continue for testing purposes.
			if (testCase == false)
			{
				result.IsValid = false;
				// A constant should be used with strings that appear more than once in your code.
				result.Feedback = TRY_AGAIN;
			}
			else
			{
				result.IsValid = true;
				// A value must be provided or else the Field will not be populated.
				result.Value = value;
			}
			return result;
		}
		/// <summary>
		/// Here is the method we're using for the PromptAsyncDelegate.
		/// </summary>
		private static async Task<FormPrompt> PromptAsync(IDialogContext context, FormPrompt prompt,
			FAQConversation state, IField<FAQConversation> field)
		{
			var preamble = context.MakeMessage();
			var promptMessage = context.MakeMessage();
			if (prompt.GenerateMessages(preamble, promptMessage))
			{
				await context.PostAsync(preamble);
			}
			// Here is where we've made a change to the default prompter.
			if (state.LastMessage != TRY_AGAIN)
			{
				await context.PostAsync(promptMessage);
			}
			state.LastMessage = promptMessage.Text;
			return prompt;
		}
	}
