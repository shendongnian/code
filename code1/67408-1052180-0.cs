    public override Dispose(bool disposing)
    {
       if (disposing)
       {
           // Dispose was called from user code. Dispose of managed resources here.
           done.Dispose();
       }
     
       // Dispose of unmanaged resources here, and invoke base dispose.
       base.Dispose(disposing);
    }
