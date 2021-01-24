    private void startingStation_SelectedIndexChanged(object sender, EventArgs e) {
      //TODO: you have to obtain Line instance here
      Line MyLine = new Line();
      // In order to avoid constant redrawing
      startingStation.BeginUpdate();
      try {
        // It is line (not List<T>) that provides GetCC() method
        foreach (Station station in line.GetCC()) {
          startingStation.Items.Add($"{station.Number} {station.Desc}");
        } 
      }
      finally {
        startingStation.EndUpdate();
      }
    }
