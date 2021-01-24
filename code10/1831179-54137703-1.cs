    var recordingFileExternalPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, AppConstants.CUSTOM_ALERT_FILENAME);
    
                if (ContextCompat.CheckSelfPermission(Android.App.Application.Context, Manifest.Permission.WriteExternalStorage) == (int)Permission.Granted)
                {
                    try
                    {
                        if (File.Exists(recordingFileExternalPath))
                        {
                            File.Delete(recordingFileExternalPath);
                        }
    
                        File.Copy(filePath, recordingFileExternalPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    UserDialogs.Instance.Alert("Permission to write to External Storage not approved, cannot save settings.", "Permission Denied", "Ok");
                }
