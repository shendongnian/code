    public class ResumableUploader {
      private SynchronizationContext _syncContext;
      public event EventHandler<ProgressChangedEventArgs> OnProgressChanged;
    
      public ResumableUploader() {
        _syncContext = SynchronizationContext.Current; //Think of this as the current thread
      }
    
      private ReportProgressChanged(int progress) {
         if(OnProgressChanged != null) {
             _syncContext.Send(s => { OnProgressChanged(this, new ProgressChangedEventArgs(progress)); }, null);  //s is any data you want to pass in, here it is unused
         }
      }
    }
