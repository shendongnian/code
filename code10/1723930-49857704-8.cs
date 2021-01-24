    var allLines = File
      .ReadAllLines("filepathgoeshere");
    // Genre name is the second line (top one is id which we skip)
    myTextBox.Text = allLines[1]; 
    // in case you want to clear existing control, not creating a new one. 
    Lst_Genre.Items.Clear();
    // Tracks
    Lst_Genre.Items.AddRange(allLines
      .Skip(2)     // Here we skip tow lines (id and genre name)
      .ToArray());
