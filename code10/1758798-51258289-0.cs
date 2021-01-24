    private void Window_PreviewDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.UnicodeText, true))
        {
            var data = e.Data.GetData(DataFormats.UnicodeText, true);
            if (data != null)
            {
                if (data is string)
                {
                    this.Title = data as string; // done!
                }
            }
        }
    }
