    for(var i = listboxFiles.Items.Count - 1; i >= 0; --i)
    {
        var item = listboxFiles[i];
        if (...)
        {
            listboxFiles.Items.RemoveAt(i);
        }
    }
