     if(Uri.IsWellFormedUriString(slct.Text,UriKind.Absolute))
     {
            Uri uri = new Uri(slct.Text);
            if (DeleteFileOnServer(uri))
            {
              nn.BalloonTipText = slct.Text + " has been deleted.";
              nn.ShowBalloonTip(30);
            }
     }
