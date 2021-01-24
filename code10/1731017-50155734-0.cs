    public MockClipboard
    {
      public StringCollection GetClipBoardInfo()
      {
        ClipboardWasRead = true;
        StringCollection col = new StringCollection();
        col.Add("...");
        return col;
      }
      public bool ClipboardWasRead { get; set; }
    }
