    public class BatchFile {
    
       private string _fileName;
    
       private BatchFile(string fileName) {
          _fileName = fileName;
       }
    
       public BatchFile Batch1 { get { return new BatchFile("Batch1.bat"); } }
       public BatchFile Batch2 { get { return new BatchFile("Batch2.bat"); } }
    
       public virtual void Execute() {
          ExecuteBatchFile(_fileName);
       }
    
    }
