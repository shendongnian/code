    public void DownloadFile(string m_uri, string m_filePath)
                {
                var webClient = new WebClient();
    
                webClient.DownloadFileCompleted += (s, e) =>
                {
                    string error = e.Error.Message;
                    //var bytes = e.Result; // get the downloaded data
                    string documentsPath = Android.OS.Environment.ExternalStorageDirectory + "/download/";
    
    
                    Intent promptInstall = new Intent(Intent.ActionView).SetDataAndType(Android.Net.Uri.FromFile(new Java.IO.File(Android.OS.Environment.ExternalStorageDirectory + "/download/" + "FileName.apk")), "application/vnd.android.package-archive");
                    promptInstall.AddFlags(ActivityFlags.NewTask);
                    StartActivity(promptInstall);
    
    
    
                };
    
                var url = new System.Uri(m_uri);
    
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
                webClient.DownloadFileAsync(url, Android.OS.Environment.ExternalStorageDirectory + "/download/FileName.apk");
    
            }
