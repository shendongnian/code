    private void CompareVersion()
    {
    	double currentVersion = 0d;
    	double appStoreversion =Convert.ToDouble(CosntValues.PlayStoreValues);
    	bool IsUpdateRequired = false;
    
    	if (Context.PackageName != null)
    	{
    		PackageInfo info = Context.PackageManager.GetPackageInfo(Context.PackageName, PackageInfoFlags.Activities);
    		string currentVersionStrig = info.VersionName;
    		currentVersion = Convert.ToDouble(currentVersionStrig);
    	}
    	try
    	{
    		if (IsUpdateRequired == false)
    		{
    			if (CheckNetConnection.IsNetConnected())
    			{
    				using (var webClient = new System.Net.WebClient())
    				{
    					var task = new VersionChecker();
    					task.Execute();
    					if ((appStoreversion.ToString() != currentVersion.ToString() && (appStoreversion > currentVersion)))
    					{
    						IsUpdateRequired = true;
    					}
    				}
    			}
    		}
    		if (IsUpdateRequired)
    		{
    			Activity.RunOnUiThread(() =>
    			{
    				AlertDialog dialog = null;
    				var Alertdialog = new Android.App.AlertDialog.Builder(Context);
    				Alertdialog.SetTitle("Update Available");
    				Alertdialog.SetMessage($"A new version of [" + appStoreversion + "] is available. Please update to version [" + appStoreversion + "] now.");
    				Alertdialog.SetNegativeButton("Cancel", (sender, e) =>
    				{
    					if (dialog == null)
    					{
    						dialog = Alertdialog.Create();
    					}
    					dialog.Dismiss();
    				});
    				Alertdialog.SetPositiveButton("Update", async (sender, e) =>
    				{
    					string appPackage = string.Empty;
    					try
    					{
    						appPackage = Application.Context.PackageName;
    						await Utilities.Logout(this.Activity);
    						var ints = new Intent(Intent.ActionView, Android.Net.Uri.Parse("market://details?id=" + appPackage));
    						ints.SetFlags(ActivityFlags.ClearTop);
    						ints.SetFlags(ActivityFlags.NoAnimation);
    						ints.SetFlags(ActivityFlags.NewTask);
    						Application.Context.StartActivity(ints);
    						//StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("market://details?id=" + "com.sisapp.in.sisapp")));
    					}
    					catch (ActivityNotFoundException)
    					{
    						var apppack = Application.Context.PackageName;
    						//Default to the the actual web page in case google play store app is not installed
    						//StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://play.google.com/store/apps/details?id=" + "com.app.in.app")));
    						await Utilities.Logout(this.Activity);
    						var ints = new Intent(Intent.ActionView, Android.Net.Uri.Parse("market://details?id=" + appPackage));
    						ints.SetFlags(ActivityFlags.ClearTop);
    						ints.SetFlags(ActivityFlags.NoAnimation);
    						ints.SetFlags(ActivityFlags.NewTask);
    						Application.Context.StartActivity(ints);
    					}
    					//this kills the app 
    					Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
    					System.Environment.Exit(1);
    				});
    				if (dialog == null)
    					dialog = Alertdialog.Create();
    				dialog.Show();
    			});
    		}
    	}
    	catch (Exception ex)
    	{
    		var objLog = new LogService();
    		objLog.MobileLog(ex, SISConst.UserName);
    	}
    }
