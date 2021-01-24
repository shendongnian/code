     private void EnableAsAdmin()
    		{
    			string driverName = "Stereo Mix";
    			string deviceId = "";
    			
    			
    			MMDevice mMDevice;
    			using (var enumerator = new NAudio.CoreAudioApi.MMDeviceEnumerator())
    			{
    				mMDevice = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Disabled).ToList().Where(d => d.FriendlyName.ToLower().Contains(driverName.ToLower())).FirstOrDefault();
    			}
    			if (mMDevice != null)
    			{
    				driverName = mMDevice.FriendlyName;
    				int charLocation = driverName.IndexOf("(", StringComparison.Ordinal);
    
    				if (charLocation > 0)
    				{
    					driverName = driverName.Substring(0, charLocation);
    					driverName = driverName.Trim();
    				}
    
    				deviceId = mMDevice.ID;
    				charLocation = deviceId.IndexOf(".{", StringComparison.Ordinal);
    
    				if (charLocation > 0)
    				{
    					deviceId = deviceId.Substring(charLocation + 1);
    					deviceId = deviceId.Trim();
    				}
    
    				if (!string.IsNullOrWhiteSpace(deviceId) && AdminHelper.IsRunAsAdmin())
    				{
    					if (Environment.Is64BitOperatingSystem)
    					{
    
    						RegistryKey localKey =
    							RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine,
    								RegistryView.Registry64);
    						localKey = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\MMDevices\Audio\Capture\" + deviceId, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.SetValue);
    						localKey.SetValue("DeviceState", 1, RegistryValueKind.DWord);
    					}
    					else
    					{
    
    						RegistryKey localKey32 =
    							RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine,
    								RegistryView.Registry32);
    						localKey32 = localKey32.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\MMDevices\Audio\Capture\" + deviceId, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.SetValue);
         localKey32.SetValue("DeviceState", 1, RegistryValueKind.DWord);
    					}
    				}
    				if (mMDevice != null)
    				{
    					if (mMDevice.State == DeviceState.Active)
    					{
    						App.Current.Dispatcher.Invoke(() =>
    						{
    							MessageBox.Show($"{driverName} Enabled ");
    						});
    					}
    				}
    			}
    			else
    			{
    				App.Current.Dispatcher.Invoke(() =>
    				{
    					MessageBox.Show($"{driverName} Coudn't Found as Disabled Device.");
    				});
    				return;
    			}
    		}
 
