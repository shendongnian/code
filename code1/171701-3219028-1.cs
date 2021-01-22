      // Collection to be populated with the record data in the file
      List<Record> records = new List<Record>();
      using (FileStream fs = new FileStream("datafile.dat", FileMode.Open))
      using (StreamReader rdr = new StreamReader(fs))
      {
        string line;
        // Read first line
        line = rdr.ReadLine();
        while (line != null)
        {   
          // Check if we have a new record
          if (line.StartsWith("G"))
          {
            // We have a start of a record so create an instance of the Record class
            Record record = new Record();
            // Add the first line to the record
            record.Lines.Add(line);
            // Read the next line
            line = rdr.ReadLine();
            // While the line is not the start of a new record or end of the file,
            // add the data to the current record instance
            while (line != null && !line.StartsWith("G"))
            {
              record.Lines.Add(line);
              line = rdr.ReadLine();
            }
            // Add the record instance to the record collection
            records.Add(record);
          }
          else
          {
            // If we get here there was something unexpected
            // So for now just move on and read the next line
            line = rdr.ReadLine();
          }
        } 
      }
