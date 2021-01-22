    Public IEnumerable<MyObj> GetObjList(string filename)
    {
      // Obvioulsly you would have some actual validation and error handling
      foreach(string line in File.ReadAllLines(filename))
      {
        string[] fields = line.Split(new char[]{','});
        MyObj obj = new MyObj();
        obj.Field = fields[0];
        obj.AnotherField = int32.Parse(fields[1]);
        yield return obj;
      }
    }
