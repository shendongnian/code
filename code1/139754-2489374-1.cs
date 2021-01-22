    private void WriteToFile<T>(
      IEnumerable<T> elementsToWrite,
      Action<T, TextWriter> writeElement) {
      var writer = ...;
      
      foreach (var element in elementsToWrite)
      {
        // do whatever you do before you write an element
        writeElement(element, writer);
        // do whatever you do after you write an element
      }
    }
    // called like so...
    WriteToFile(listOfFoo, (foo, writer) =>
      writer.Write("{0}, {1} = {2}", foo.FP1, foo.FP2, foo.FP3);
    WriteToFile(listOfBar, (bar, writer) =>
      writer.Write("{0}/{1}[@x='{2}']", bar.BP1, bar.BP2, bar.BP3);
