    private void filterTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        var cvs = TryFindResource("FooCVS") as CollectionViewSource;
        if (cvs != null)
        {
            if (cvs.View != null)
                cvs.View.Refresh();
        }
        cvs = TryFindResource("QuxCVS") as CollectionViewSource;
        if (cvs != null)
        {
            if (cvs.View != null)
                cvs.View.Refresh();
        }
        cvs = TryFindResource("BarCVS") as CollectionViewSource;
        if (cvs != null)
        {
            if (cvs.View != null)
                cvs.View.Refresh();
        }
    }
