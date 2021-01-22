    public Slot(Type[] exclusiveLootTypes) {
        // be sure and check that each Type is a subtype of Loot!
    }
    // Construction looks like:
    new Slot(new[] {GetType(AmmoContainer), GetType(GemContainer) /* or whatever */});
