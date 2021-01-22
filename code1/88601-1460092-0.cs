    private bool _Busy = false;
    public override void SubmitChanges(ConflictMode failureMode) {
      if (_Busy)
        return; // no action & no error; just let this SubmitChanges handle all nested submissions.
      try {
        _Busy = true;
        BeginTransaction();
        Dictionary<MyClass, bool> myUpdates = new Dictionary<MyClass, bool>();
        Dictionary<MyClass, bool> myInserts = new Dictionary<MyClass, bool>();
        Dictionary<MyClass, bool> myDeletes = new Dictionary<MyClass, bool>();
        SynchronizeChanges(myUpdates, GetChangeSet().Updates);
        SynchronizeChanges(myInserts, GetChangeSet().Inserts);
        SynchronizeChanges(myDeletes, GetChangeSet().Deletes);
        while (myInserts.Any(i => i.Value == false) || myUpdates.Any(u => u.Value == false) || myDeletes.Any(d => d.Value == false)) {
          List<MyClass> tmp = myInserts.Where(i => i.Value == false).Select(i => i.Key).ToList();
          foreach (MyClass mc in tmp) {
            mc.BeforeInsert();
            myInserts[lt] = true;
          }
          tmp = myUpdates.Where(u => u.Value == false).Select(u => u.Key).ToList();
          foreach (MyClass mc in tmp) {
            mc.BeforeUpdate();
            myInserts[lt] = true;
          }
          tmp = myDeletes.Where(d => d.Value == false).Select(d => d.Key).ToList();
          foreach (MyClass mc in tmp) {
            mc.BeforeDelete();
            myInserts[lt] = true;
          }
          // before calling base.SubmitChanges(), make sure that nothing else got changed:
          SynchronizeChanges(myUpdates, GetChangeSet().Updates);
          SynchronizeChanges(myInserts, GetChangeSet().Inserts);
          SynchronizeChanges(myDeletes, GetChangeSet().Deletes);
        }
        base.SubmitChanges(failureMode);
        // now the After- methods
        foreach (MyClass mc in mcInserts.Keys) {
          mc.AfterInsert();
        }
        foreach (MyClass mc in mcUpdates.Keys) {
          mc.AfterUpdate();
        }
        foreach (MyClass mc in mcDeletes.Keys) {
          mc.AfterDelete();
        }
        CommitTransaction();
      } catch {
        RollbackTransaction();
        throw;
      } finally {
        _Busy = false;
      }
      // now, just in case any of the After... functions triggered a change:
      if (GetChangeSet().Deletes.Count + GetChangeSet().Inserts.Count + GetChangeSet().Updates.Count > 0)
        SubmitChanges();
    }
    private void SynchronizeChanges(Dictionary<MyClass, bool> mcDict, IList<object> iList) {
      var q = iList.OfType<MyClass>().Where(i => !mcDict.ContainsKey(i));
      q.ToList().ForEach(i => mcDict[i] = false);
    }
