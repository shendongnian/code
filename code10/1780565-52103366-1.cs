    IEnumerable<int> Weird(bool b)
    {
      if (b) throw new Exception();
      yield return 1;
    }
    ...
    IEnumerable<int> x = null;
    try
    {
      x = Weird(true); // Should throw, right?
    }
    catch(Exception ex)
    {
      // Nope; this is unreachable
    }
    foreach(int y in x) // the throw happens here!
