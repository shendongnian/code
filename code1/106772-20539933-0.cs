        LinkedResource imagelink = new LinkedResource(Server.MapPath("~/images/gmail_top.jpg"));
        LinkedResource imagelink1 = new LinkedResource(Server.MapPath("~/images/gmail_btm.jpg"));
        imagelink.ContentId = "imageId";
        imagelink1.ContentId = "imageId1";
        imagelink.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
        htmlView.LinkedResources.Add(imagelink);
        imagelink.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
        htmlView.LinkedResources.Add(imagelink1);
        Mail.AlternateViews.Add(htmlView);
