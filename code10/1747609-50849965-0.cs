            var ReportAbsolutePath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Folder";
            Directory.CreateDirectory(ReportAbsolutePath);
            try
            {
                string reportSavedPath = ReportAbsolutePath + "/ReportName.pdf";
                var fileUri = Android.Net.Uri.FromFile(new Java.IO.File(reportSavedPath));
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += (object sender, AsyncCompletedEventArgs e) =>
                {
                    Intent intent = new Intent(Intent.ActionView);
                    intent.SetDataAndType(fileUri, mimeType);
                    var notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;
                    var notification = new Notification(Resource.Drawable.app_icon, "Title");
                    notification.Flags = NotificationFlags.AutoCancel;
                    notification.SetLatestEventInfo(this, "title", "desc", 
                    PendingIntent.GetActivity(this, 0, mIntent, 0));
                    notificationManager.Notify(1, notification);
                    ShowToastMessage("Report downloaded successfully.");
                };
                webClient.DownloadFileAsync(new Uri(reportUrl), reportSavedPath);
            }
            catch (Exception ex)
            {
                ShowToastMessage("Error occurred while downloading the report");
            }
