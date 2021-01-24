    lstAvailableTrains.Items.Clear();
    foreach (string line in lines)
    {
      if (line.Contains(stringToSearch))
      {     
         lstAvailableTrains.Items.Add(line);
      }
    }
