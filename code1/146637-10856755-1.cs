    private void Hyperlink_RequestNavigate(object sender, 
        System.Windows.Navigation.RequestNavigateEventArgs e) {
        System.Diagnostics.Process.Start(
            new System.Diagnostics.ProcessStartInfo(e.Uri.AbsoluteUri)
         );
        e.Handled = true;
    } 
