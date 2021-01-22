    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    class FileCounter
    {
      private readonly int _clusterSize;
      private long _filesCount;
      private long _size;
      private long _diskSize;
      public void Count(string rootPath)
      {
        // Enumerate files (without real execution of course)
        var filesEnumerated = new DirectoryInfo(rootPath)
                                  .EnumerateFiles("*", SearchOption.AllDirectories);
        // Do in parallel
        Parallel.ForEach(filesEnumerated, GetFileSize);
      }
		
	  /// <summary>
      /// Get real file size and add to total
      /// </summary>
      /// <param name="fileInfo">File information</param>
      private void GetFileSize(FileInfo fileInfo)
      {
        Interlocked.Increment(ref _filesCount);
        Interlocked.Add(ref _size, fileInfo.Length);
      }
    }
    var fcount = new FileCounter("F:\\temp");
    fcount.Count();
