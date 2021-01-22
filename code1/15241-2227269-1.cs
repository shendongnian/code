	namespace MyApp
	{
		class MainWindow ....
		{
			...
	
			protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
			{
				// store wnd size settings
				mSettings.MainWndHeight = MyAppSettings.Default.MainWndHeight;
				mSettings.MainWndWidth = MyAppSettings.Default.MainWndWidth;
				mSettings.MainWndTop = MyAppSettings.Default.MainWndTop;
				mSettings.MainWndLeft = MyAppSettings.Default.MainWndLeft;
				mSettings.Save();
				base.OnClosing(e);
			}
		}
		
		public sealed class MyAppSettings : System.Configuration.ApplicationSettingsBase
		{
			private static MyAppSettings defaultInstance = ((MyAppSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new MyAppSettings())));
			public static MyAppSettings Default
			{
				get { return defaultInstance; }
			}
	
			[System.Configuration.UserScopedSettingAttribute()]
			[System.Configuration.DefaultSettingValueAttribute("540")]
			public int MainWndHeight
			{
				get { return (int)this["MainWndHeight"]; }
				set { this["MainWndHeight"] = value; }
			}
	
			[System.Configuration.UserScopedSettingAttribute()]
			[System.Configuration.DefaultSettingValueAttribute("790")]
			public int MainWndWidth
			{
				get { return (int)this["MainWndWidth"]; }
				set { this["MainWndWidth"] = value; }
			}
	
			[System.Configuration.UserScopedSettingAttribute()]
			[System.Configuration.DefaultSettingValueAttribute("300")]
			public int MainWndTop
			{
				get { return (int)this["MainWndTop"]; }
				set { this["MainWndTop"] = value; }
			}
	
			[System.Configuration.UserScopedSettingAttribute()]
			[System.Configuration.DefaultSettingValueAttribute("300")]
			public int MainWndLeft
			{
				get { return (int)this["MainWndLeft"]; }
				set { this["MainWndLeft"] = value; }
			}
		}
	}
