        WebClient client = new WebClient();
        try
        {
            string response =
                client.DownloadString("http://www.example.com/tester.cgi");
            // We at least got the file back from the server
            // You could optionally look at the contents of the file
            // for additional error indicators      
            if (response.Contains("ERROR: Something"))
            {
                // Handle
            }
        }
        catch (WebException ex)
        {
            // We couldn't get the file.
            // ... handle, depending on the ex
            //
            // For example, by looking at ex.Status:
            switch (ex.Status)
            {
                case WebExceptionStatus.NameResolutionFailure:
                    // ...
                break;
                // ...
            }
        }
