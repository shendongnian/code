	public class DialogAsync : Java.Lang.Object, IDialogInterfaceOnClickListener, IDialogInterfaceOnCancelListener
	{
		readonly TaskCompletionSource<bool?> taskCompletionSource = new TaskCompletionSource<bool?>();
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
			taskCompletionSource.SetCanceled();
		}
		void SetResult(bool? selection)
		{
			taskCompletionSource.SetResult(selection);
		}
		public async static Task<bool?> Show(Activity context, string title, string message)
		{
			using (var listener = new DialogAsync())
			using (var dialog = new AlertDialog.Builder(context)
																.SetPositiveButton("Yes", listener)
																.SetNegativeButton("No", listener)
																.SetOnCancelListener(listener)
																.SetTitle(title)
																.SetMessage(message))
			{
				dialog.Show();
				return await listener.taskCompletionSource.Task;
			}
		}
	}
