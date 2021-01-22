      public enum RetrievalMethod
      {
         Basic,
         Existing
      }
      public class Helper<T> : IHelper<T> where T : IMyObj
      {
         public T Get(RetrievalMethod rm)
         {
            switch(rm)
            {
               case RetrievalMethod.Basic:
                  return GetBasic();
               case RetrievalMethod.Existing:
                  return GetExisting();
            }
         }
    ...
      }
    ...
         private void AddData(Receiver receiver, RetrievalMethod rm)
         {
            var aHelper = new AHelper();
            var bHelper = new BHelper();
            var cHelper = new CHelper();
            receiver.ObjA = aHelper.Get(rm);
            receiver.ObjB = bHelper.Get(rm);
            receiver.ObjC = cHelper.Get(rm);
         }
