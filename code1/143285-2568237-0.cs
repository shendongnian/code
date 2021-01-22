    class LookupService {
      private WeakHashtable<string,List<Count>> _map = new WeakHashtable<string,List<County>>();
      public List<County> GetCounties(string state) {
        List<Count> found;
        if ( !_map.TryGetValue(state, out found)) { 
          var db = new LookUpRepository();
          found = db.GetCounties(state);
          _map.Add(state,found);
        }
        return found;
      }
    }
