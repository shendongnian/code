    private void serialPort1_DataReceived(
      object sender,
      SerialDataReceivedEventArgs e)
    {
      // Add the new data to what we have.
      _serialRxString += serialPort1.ReadExisting();
      // Each line starts with a '$'.
      string[] lines = _serialRxString.Split(
        new char[] { '$' },
        StringSplitOptions.None);
      // Don't process the last one yet, it might not be complete.
      for (int i = 0; i < lines.Length - 1; i++)
      {
        // Check if it's the line we're looking for.
        if (lines[i].StartsWith("GPGGA"))
        {
          string[] values = lines[i].Split(new char[] { ',' });
          // Do what you want with the values from the $GPGGA line.
        }
      }
      // Keep the last line, since it might not be complete yet.
      _serialRxString = lines.Last();
    }
