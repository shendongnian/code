    class ExceptionFolderEntryMeta
    {
      public ExceptionFolderEntry ExceptionFolderEntry { get; set; }
      public DateTime SortBy { get; set; }
      public bool IsStartTime { get; set; }
    }
    var exceptionFolderEntries = new List<ExceptionFolderEntry>();
    var mergeList = exceptionFolderEntries 
      .Where(efe => efe.StartTime.HasValue)
      .Select(efe => new ExceptionFolderEntryMeta
        {
          ExceptionFolderEntry  = efe,
          SortBy = efe.StartTime,
          IsStartTime = true,
        })
      .Concat(exceptionFolderEntries 
        .Where(efe => efe.EndTime.HasValue)
        .Select(efe => new ExceptionFolderEntryMeta
          {
            ExceptionFolderEntry  = efe,
            SortBy = efe.EndTime,
            IsStartTime = false,
         }))
      .OrderBy(efem => efem.SortBy)
      .ToList())
