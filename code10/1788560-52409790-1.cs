    class abstract BaseFileBackup
    {
      internal BaseFileBackup Fallback;
      internal BaseFileBackup(BaseFileBackup fallback) { Fallback = fallback; }
      internal BaseFileBackup() { }
    
      internal abstract void DoBackupWork();
    
      internal void Backup()
      {
        try { DoBackupWork(); }
        catch { if(Fallback != null) Fallback.Backup(); else throw; }
      }
    }
    
    class BackUpMechanism1 : IFileBackup, BaseFileBackup
    {
        internal BackUpMechanism1 (BaseFileBackup fallback): base(fallback) {}
        internal BackUpMechanism1 (): base() {}
    
        internal void DoBackupWork()
        {
            //Back it up
        }
    }
    
    class BackUpMechanism2 : IFileBackup, BaseFileBackup
    {
        internal BackUpMechanism2 (BaseFileBackup fallback): base(fallback) {}
        internal BackUpMechanism2 (): base() {}
    
        internal void DoBackupWork()
        {
            //Back it up in another way
        }
    }
    
    // and to call it
    class Client
    {
        static void Main()=>
            new BackupMechanism2(new BackupMechanism1()).Backup();
    }
