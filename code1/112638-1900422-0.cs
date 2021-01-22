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
      public static void Demo(){
        var l=new ReaderWriterLockSlim();
        using(l.ForUpgradeableRead()){
          if(CacheExpires()){   
             using(l.ForWrite()){
               RefreshCache();
             }
          }
          return CachedValue();
        }
      }
    }
