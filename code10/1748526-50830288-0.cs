    private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
    {
        if (e.IsIntermediate)
        {
            System.Diagnostics.Debug.WriteLine("scroll ongoing");
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("scroll finish");
        }
    }
