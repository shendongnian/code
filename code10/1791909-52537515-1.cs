    foreach (ComboBoxItem b in cboServers.Items)
    {
          if (b.Content.ToString().ToLower().Contains("prod")) 
          { b.Visibility = Visibility.Visible; } 
          else 
          { b.Visibility = Visibility.Collapsed; }
    }
