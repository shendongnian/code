    Run run2 = new Run("this is a hyperlink");
    Hyperlink hlink = new Hyperlink(run2);
    hlink.NavigateUri = new Uri("http://www.google.com");
    hlink.RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(hlink_RequestNavigate);
    paragraph.Inlines.Add(hlink);
    void hlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
    {
        Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
        e.Handled = true;
    }
