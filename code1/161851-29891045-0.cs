   			try
   			{
   				//Instantiate an Enumerator to find audio devices
      				NAudio.CoreAudioApi.MMDeviceEnumerator MMDE = new NAudio.CoreAudioApi.MMDeviceEnumerator();
           	   			//Get all the devices, no matter what condition or status
	   			NAudio.CoreAudioApi.MMDeviceCollection DevCol = MMDE.EnumerateAudioEndPoints(NAudio.CoreAudioApi.DataFlow.All, NAudio.CoreAudioApi.DeviceState.All);
				//Loop through all devices
				foreach (NAudio.CoreAudioApi.MMDevice dev in DevCol)
				{
					try
					{
						if (dev.State == NAudio.CoreAudioApi.DeviceState.Active)
						{
							var newVolume = (float)Math.Max(Math.Min(level, 100),0) / (float)100;
							//Set at maximum volume
							dev.AudioEndpointVolume.MasterVolumeLevelScalar = newVolume;
							dev.AudioEndpointVolume.Mute = level == 0;
							//Get its audio volume
							_log.Info("Volume of " + dev.FriendlyName + " is " + dev.AudioEndpointVolume.MasterVolumeLevelScalar.ToString());
						}
						else
						{
							_log.Debug("Ignoring device " + dev.FriendlyName + " with state " + dev.State);
						}
					}
					catch (Exception ex)
					{
						//Do something with exception when an audio endpoint could not be muted
						_log.Warn(dev.FriendlyName + " could not be muted with error " + ex);
					}
				}
			}
			catch (Exception ex)
			{
				//When something happend that prevent us to iterate through the devices
				_log.Warn("Could not enumerate devices due to an excepion: " + ex.Message);
			}
		}
