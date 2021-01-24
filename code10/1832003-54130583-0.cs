    if (oldLines.Count() == newLines.Count())
    {
        lbOne.Items.Add(txtID.Text + " does not exist.");
    }
    else
    {
        lbOne.Items.Add(txtID.Text + " was deleted.");
    }
