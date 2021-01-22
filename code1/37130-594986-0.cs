    if (DateTime.Now - lastClick > TimeSpan.FromMilliseconds(400))
    {
      lastClick = DateTime.Now;
      ToggleRows(grid.SelectedRows);
    }
