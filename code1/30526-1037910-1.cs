    Locker locker = new Locker();
    locker.UserReference.EntityKey = new System.Data.EntityKey("entities.User", "ID", userID);
    locker.LockerStyleReference.EntityKey = new EntityKey("entities.LockerStyle", "ID", lockerStyleID);
    locker.NameplateReference.EntityKey = new EntityKey("entities.Nameplate", "ID", nameplateID);
    entities.AddLocker(locker);
    entities.SaveChanges();
