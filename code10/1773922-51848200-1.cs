       private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
       {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
            e.Handled = true;
       }
