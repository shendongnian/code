    Locker l = new Locker();
    1.UserReference.EntityKey = new System.Data.EntityKey("entities.User", "ID", userID);
    l.LockerStyleReference.EntityKey = new EntityKey("entities.LockerStyle", "ID", lockerStyleID);
    l.NameplateReference.EntityKey = new EntityKey("entities.Nameplate", "ID", nameplateID);
    entities.AddLocker(l);
    entities.SaveChanges();
