    var steps = new List<Tuple<Action, Status>>() {
      Tuple.Create(performStep1, Status.Error),
      Tuple.Create(performStep2, Status.Warning)
    };
    var status = Status.Success;
    foreach (var item in steps) {
      try { item.Item1(); }
      catch (Exception ex) {
        log(ex);
        status = item.Item2;
        break;
      } 
    }
    // "Finally" code here
