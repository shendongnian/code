    // initialize the data structures
    var priorityQueue = new SortedDictionary<Record, Stream>();
    var streams = new List<Stream>();
    var outStream = null; 
    try
    {
      // open the streams.
      outStream = OpenOutputStream();
      foreach(var filename in filenames)
        streams.Add(GetFileStream(filename));
      // initialize the priority queue
      foreach(var stream in streams)
      {
        var record = ReadRecord(stream);
        if (record != null)
          priorityQueue.Add(record, stream);
      // the main loop
      while(!priorityQueue.IsEmpty)
      {
         var record = priorityQueue.Smallest;
         var smallestStream = priorityQueue[record];
         WriteRecord(record, outStream);
         priorityQueue.Remove(record);
         var newRecord = ReadRecord(smallestStream);
         if (newRecord != null)
           priorityQueue.Add(newRecord, smallestStream);
      }
    }
    finally { clean up the streams }
