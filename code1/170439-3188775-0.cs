    var maxItem = 
      items.Aggregate(
        new { Max = Int32.MinValue, Item = (Item)null },
        (state, el) => (el.ID > state.Max) 
          ? new { Max = el.ID, Item = el } : state).Item;
