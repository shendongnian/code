     public void GetWordFrequencyResource(Action<string> callback)
     {
         WebClient client = new WebClient();
         client.OpenReadAsync += (s, args) =>
         {
           try
           {
             var zipRes = new StreamResourceInfo(args.Result, null)
             var txtRes = Application.GetResourceStream(zipRes, new Uri("WordFrequency.txt", UriKind.Relative));
             string result = new StreamReader(txtRes.Stream).ReadToEnd();
         
             callback(result);
           }
           catch
           {
             callback(null);  //Fetch failed.
           } 
         }
         client.OpenReadAsync(new Uri("WordFrequency.zip", UriKind.Relative"));
     }
