    Xamarin.Forms.MessagingCenter.Subscribe<InvoicePage, string>(this, "html", (sender, html) => 
        {
            //I changed this path to be a public path so external apps can access the file. 
            //Otherwise you would have to grant Chrome access to your private app files
            var documentsPath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).AbsolutePath;
            Directory.CreateDirectory(documentsPath);
            
            //This creates the full file path to file
            string filePath = System.IO.Path.Combine(documentsPath, "invoice.html");
    
            //writes to file (no need to create it first as the below will create if necessary)
            File.WriteAllText(filePath, html);
    
            //opens file
            Android.Net.Uri uri = Android.Net.Uri.FromFile(new Java.IO.File(filePath));
            Intent intent = new Intent(Intent.ActionView, uri);
            intent.AddFlags(ActivityFlags.NewTask);
            intent.SetClassName("com.android.chrome", "com.google.android.apps.chrome.Main");
               
            this.StartActivity(intent);
        });
