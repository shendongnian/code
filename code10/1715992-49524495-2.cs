	public class StatusBarColor : IStatusBarColor
	{
		public void MakeMe(string color)
		{
			if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
			{
				var c = MainActivity.context as FormsAppCompatActivity;
				c?.RunOnUiThread(() => c.Window.SetStatusBarColor(Color.ParseColor(color)));
			}
		}
		public void CoreMeltDown()
		{
			Task.Run(async () =>
			{
				for (int i = 0; i < 10; i++)
				{
					switch (i%2)
					{
						case 0:
							MakeMe($"#{Integer.ToHexString(Color.Red.ToArgb())}");
							break;
						case 1:
							MakeMe($"#{Integer.ToHexString(Color.White.ToArgb())}");
							break;
					}
					await Task.Delay(200);
				}
			});
		}
	}
