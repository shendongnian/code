	SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
	SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
	SystemEvents.SessionEnding += SystemEvents_SessionEnding;
	SystemEvents.SessionEnded += SystemEvents_SessionEnded;
	private async void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
	{
		await vm.PowerModeChanged(e.Mode);
	}
	private async void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
	{
		await vm.PowerModeChanged(e.Mode);
	}
	private async void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
	{
		await vm.SessionSwitch(e.Reason);
	}
	private async void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
	{
		if (e.Reason == SessionEndReasons.Logoff)
		{
			await vm.UserLogoff();
		}
	}
	private async void SystemEvents_SessionEnded(object sender, SessionEndedEventArgs e)
	{
		if (e.Reason == SessionEndReasons.Logoff)
		{
			await vm.UserLogoff();
		}
	}
