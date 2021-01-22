    // stage 1
    DateTime dt = DateTime.MinValue.AddYears(2009);
    PersistTicksToSomewhere(dt.Ticks);
    // stage 2
    long ticks = GetPersistedTicksFromSomewhere();
    DateTime dt = new DateTime(ticks).AddMonths(8);
    PersistTicksToSomewhere(dt.Ticks);
    // stage 3
    long ticks = GetPersistedTicksFromSomewhere();
    DateTime dt = new DateTime(ticks).AddDays(20);
    PersistTicksToSomewhere(dt.Ticks);
    // etc etc
