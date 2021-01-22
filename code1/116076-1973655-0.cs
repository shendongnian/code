    public class SomeClass {
      private readonly object listLock = new object();
      private readonly List<string> yourList = new List<string>();
    
      public void DeleteItem(string item) {
        lock (listLock) {
          yourList.Remove(item)
        }
      }
    }
