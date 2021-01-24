	public class DialogAsync : Java.Lang.Object, IDialogInterfaceOnClickListener, IDialogInterfaceOnCancelListener
	{
		readonly ManualResetEvent resetEvent = new ManualResetEvent(false);
		CancellationTokenSource cancellationTokenSource;
		bool? result;
		public DialogAsync(IntPtr handle, Android.Runtime.JniHandleOwnership transfer) : base(handle, transfer) { }
		public DialogAsync() { }
		public void OnClick(IDialogInterface dialog, int which)
		{
			switch (which)
			{
				case -1:
					SetResult(true);
					break;
				default:
					SetResult(false);
					break;
			}
		}
		public void OnCancel(IDialogInterface dialog)
		{
			cancellationTokenSource.Cancel();
			SetResult(null);
		}
		void SetResult(bool? selection)
		{
			result = selection;
			resetEvent.Set();
		}
		public async static Task<bool?> Show(Activity context, string title, string message, CancellationTokenSource source)
		{
			using (var listener = new DialogAsync())
			using (var dialog = new AlertDialog.Builder(context)
																.SetPositiveButton("Yes", listener)
																.SetNegativeButton("No", listener)
																.SetOnCancelListener(listener)
																.SetTitle(title)
																.SetMessage(message))
			{
				listener.cancellationTokenSource = source;
				context.RunOnUiThread(() => { dialog.Show(); });
				await Task.Run(() => { listener.resetEvent.WaitOne(); }, source.Token);
				return listener.result;
			}
		}
	}
