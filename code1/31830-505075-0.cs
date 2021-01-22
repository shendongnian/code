    void OpenBrowser(string url)
    {
        try
        {
            Mouse.OverrideCursor = Cursors.AppStarting;
            Process.Start(url);
        }
        catch (Exception)
        {
        }
        finally
        {
            Mouse.OverrideCursor = null;
        }
    }
