    public static foo[] GetFoo(FileInfo fInfo)
    {
      var provider = new ExcelStorage(typeof(foo));
      provider.StartRow = 2;
      provider.StartColumn = 1;
      provider.FileName = fInfo.FullName;
      foo[] res = provider.ExtractRecords();
      return res;
    }
