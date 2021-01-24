	[Serializable]
	public class ChildDialog : IDialog<object>
	{
		private string _data;
		public ChildDialog(string data)
		{
			_data = data
		}
		public Task StartAsync(IDialogContext context)
		{
			if (_data.Equals("YES"))
			{
				context.Wait(MessageReceivedAsync);
			}
			else
			{
				context.Wait(WaitAsync);
			}
			return Task.CompletedTask;
		}
		private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
		{
			// Respond to a message from the user
		}
		private async Task WaitAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
		{
			context.Wait(MessageReceivedAsync);
		}
	}
