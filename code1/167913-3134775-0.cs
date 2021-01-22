    private IEnumerable<Int16> getShorts(string fileName, int start, int count)
    using(var stream = File.OpenRead(fileName))
    {
       stream.Seek(start);
       var reader = new BinaryReader(stream);
       var list = new List<int16>(count);
       for(var i = 0;i<count;i++)
       {
          list.Add(reader.ReadInt16());
       }
    }
