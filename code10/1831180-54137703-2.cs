    try
                {
                    // the urgent channel
                    var urgentChannelName = GetString(Resource.String.noti_chan_urgent);
                    var urgentChannelDescription = GetString(Resource.String.noti_chan_urgent_description);
    
                    
                    // set the vibration patterns for the channels
                    long[] urgentVibrationPattern = { 100, 30, 100, 30, 100, 200, 200, 30, 200, 30, 200, 200, 100, 30, 100, 30, 100, 100, 30, 100, 30, 100, 200, 200, 30, 200, 30, 200, 200, 100, 30, 100, 30, 100 };
                    
                    // Creating an Audio Attribute
                    var alarmAttributes = new AudioAttributes.Builder()
                        .SetContentType(AudioContentType.Speech)
                        .SetUsage(AudioUsageKind.Notification).Build();
    
                    // Create the uri for the alarm file
    
                    var recordingFileDestinationPath = System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, AppConstants.CUSTOM_ALERT_FILENAME);
    
                    Android.Net.Uri urgentAlarmUri = Android.Net.Uri.Parse(recordingFileDestinationPath);
    
    
                    
                    var chan1 = new NotificationChannel(PRIMARY_CHANNEL_ID, urgentChannelName, NotificationImportance.High)
                    {
                        Description = urgentChannelDescription
                    };
                  
    
                    // set the urgent channel properties
                    chan1.EnableLights(true);
                    chan1.LightColor = Color.Red;
                    chan1.SetSound(urgentAlarmUri, alarmAttributes);
                    chan1.EnableVibration(true);
                    chan1.SetVibrationPattern(urgentVibrationPattern);               
                    chan1.SetBypassDnd(true);
                    chan1.LockscreenVisibility = NotificationVisibility.Public;
    
              
                    
                    var manager = (NotificationManager)GetSystemService(NotificationService);
    
                    // create chan1  which is the urgent notifications channel
                    manager.CreateNotificationChannel(chan1);
                 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
