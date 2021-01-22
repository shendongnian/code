    /// <summary>If you use this class frequently from multiple threads, expect a lot of blocking. In that case,
    /// might want to make this a non-static class and have an instance per thread.</summary>
    public static class RecursionChecker
    {
      #if DEBUG
      private static HashSet<ReentrancyInfo> ReentrancyNotes = new HashSet<ReentrancyInfo>();
      private static object LockObject { get; set; } = new object();
      private static void CleanUp(HashSet<ReentrancyInfo> notes) {
        List<ReentrancyInfo> deadOrStale = notes.Where(info => info.IsDeadOrStale()).ToList();
        foreach (ReentrancyInfo killMe in deadOrStale) {
          notes.Remove(killMe);
        }
      }
      #endif
      public static void Check(object target, int maxOK = 10, int staleMilliseconds = 1000)
      {
        #if DEBUG
        lock (LockObject) {
          HashSet<ReentrancyInfo> notes = RecursionChecker.ReentrancyNotes;
          foreach (ReentrancyInfo note in notes) {
            if (note.HandlePotentiallyRentrantCall(target, maxOK)) {
              break;
            }
          }
          ReentrancyInfo newNote = new ReentrancyInfo(target, staleMilliseconds);
          newNote.HandlePotentiallyRentrantCall(target, maxOK);
          RecursionChecker.CleanUp(notes);
          notes.Add(newNote);
        }
        #endif
      }
    }
