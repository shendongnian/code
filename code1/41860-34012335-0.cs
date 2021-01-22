            //get the full URL
            Uri myUri = new Uri(Request.Url.AbsoluteUri);
            //get any parameters
            string strStatus = HttpUtility.ParseQueryString(myUri.Query).Get("status");
            string strMsg = HttpUtility.ParseQueryString(myUri.Query).Get("message");
            switch (strStatus.ToUpper())
            {
                case "OK":
                    webMessageBox.Show("EMAILS SENT!");
                    break;
                case "ER":
                    webMessageBox.Show("EMAILS SENT, BUT ... " + strMsg);
                    break;
            }
