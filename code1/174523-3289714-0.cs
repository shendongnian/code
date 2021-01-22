    public Form GetWindow(RosterItem roster) {
      Form result;
      lock(windowCollection) {
        if (windowCollection.TryGetValue(roster, out result))
          return result;
        result = new MyForm(roster);
        windowCollection.Add(roster, result);
        return result;
      }
    }
