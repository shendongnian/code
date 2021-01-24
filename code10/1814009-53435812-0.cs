    var newUpdates = new List<Entity>(); //overall list to add
    var updatesToAdd = new List<Entity>();  //later list to add
    var Ids = updatesToAdd.Select(x => x.Id).ToList();  //this line chagned
    newUpdates.RemoveAll(x => Ids.Contains(x.Id));
    newUpdates.AddRange(updatesToAdd);
