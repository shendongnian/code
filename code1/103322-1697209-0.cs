    var items = InitializeLibrary();
    pBar.Maximum = items.Length;
    foreach (Song s in items)
    {
        Library.AddSong(s);
        pBar.Value++;
    }
