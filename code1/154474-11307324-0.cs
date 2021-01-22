    public class TempFileStream : Stream
    {
      private readonly string _filename;
      private readonly FileStream _fileStream;
        
      public TempFileStream()
      {
         this._filename = Path.GetTempFileName();
         this._fileStream = File.Open(this._filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
      }
        
      public override bool CanRead
      {
       get
        {
        return this._fileStream.CanRead;
        }
       }
        
    // and so on with wrapping the stream to the underlying filestream
...
   
        // finally overrride the Dispose Method and remove the temp file     
    protected override void Dispose(bool disposing)
      {
          base.Dispose(disposing);
            
      if (disposing)
      {
       this._fileStream.Close();
       this._fileStream.Dispose();
        
       try
       {
          File.Delete(this._filename);
       }
       catch (Exception)
       {
         // if something goes wrong while deleting the temp file we can ignore it.
       }
      }
   
