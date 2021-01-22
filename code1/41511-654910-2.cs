    Random rnd = ...; // Assume a suitable Random instance
    List<MyEntity> results = context.MyEntity
                                    .Where(en => en.type == myTypeVar)
                                    .ToList();
    results.Shuffle(rnd); // Assuming an extension method on List<T>
