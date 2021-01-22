    public class ActionMessages : IEnumerable<string>
    {
      private IEnumerable<Action> actions;
    
      public IEnumerator<string> GetEnumerator()
      {
        int foldCount = 0;    
        foreach(var action in this.actions) {
          if (action.type=='fold')
            foldCount++;
          else {
            if (foldCount>0)
              yield return foldCount.ToString() + " folds";
            foldCount = 0;
            yield return action.ToString();
          }
        }
        if (foldCount>0)
          yield return foldCount.ToString() + " folds";
      }
    
      // Constructors
    
      public ActionMessages (IEnumerable<Action> actions)
      {
        this.actions = actions;
      }
    }
