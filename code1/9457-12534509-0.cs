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
                    //Show us the human understandable name of the device
                    System.Diagnostics.Debug.Print(dev.FriendlyName);
                    //Mute it
                    dev.AudioEndpointVolume.Mute = true;
                }
                catch (Exception ex)
                {
                    //Do something with exception when an audio endpoint could not be muted
                }
            }
        }
        catch (Exception ex)
        {
            //When something happend that prevent us to iterate through the devices
        }
