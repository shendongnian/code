    public static class ReaderWriterLockExt{
      public static IDisposable ForRead(ReaderWriterLockSlim rwLock){
        return new ReaderWriterLockSection(rwLock,ReaderWriterLockType.Read);
      }
      public static IDisposable ForWrite(ReaderWriterLockSlim rwLock){
        return new ReaderWriterLockSection(rwLock,ReaderWriterLockType.Write);
      }
      public static IDisposable ForUpgradeableRead(ReaderWriterLockSlim wrLock){
        return new ReaderWriterLockSection(rwLock,ReaderWriterLockType.UpgradeableRead);
      }
    }
    public static class Foo(){
      private static readonly ReaderWriterLockSlim l=new ReaderWriterLockSlim(); // our lock
      public static void Demo(){
        using(l.ForUpgradeableRead()){ // we might need to write..
          if(CacheExpires()){   // checks the scenario where we need to write
             using(l.ForWrite()){ // will request the write permission
               RefreshCache();
             } // relinquish the upgraded write
          }
          // back into read mode
          return CachedValue();
        } // release the read 
      }
    }
