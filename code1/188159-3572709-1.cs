       WebClient wc = new WebClient();
       wc.UploadProgressChanged += (sender, evtarg) =>
                {
                    Console.WriteLine(evtarg.ProgressPercentage);
                };
            wc.UploadDataCompleted += (sender, evtarg) =>
                {
                    String nResult;
                    if (evtarg.Result != null)
                    {
                        nResult = Encoding.ASCII.GetString(evtarg.Result);
                        Console.WriteLine("STATUS : " + nResult);
                    }
                    else
                        Console.WriteLine("Unexpected Error");
                };
         
            String sp= "npcgi??no=" + phoneNumber + "&msg=" + message;
            System.Uri uri = new Uri("http://x.x.x.x/cgi-bin/");
            wc.UploadDataAsync(uri, System.Text.Encoding.ASCII.GetBytes(sb);
