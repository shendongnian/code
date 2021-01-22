    var itemsToRemove = new ArrayList();  // should use generic List if you can
    foreach (var item in originalArrayList) {
      if (...) {
        itemsToRemove.Add(item);
      }
    }
    foreach (var item in itemsToRemove) {
      originalArrayList.Remove(item);
    }
