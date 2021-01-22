    if (NewValue < progressBar.Maximum)
    {
      progressBar.Value = NewValue + 1;
      progressBar.Value--;
    }
    else
    {
      progressBar.Maximum++;
      progressBar.Value = progressBar.Maximum;
      progressBar.Value--;
      progressBar.Maximum--;
    }
