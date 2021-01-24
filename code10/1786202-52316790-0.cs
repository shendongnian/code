    public class FileScanCore
    {
      public delegate void ProgressUpdateHandler(object sender, float progress);
      public event ProgressUpdateHandler OnProgressUpdate;
    ...
