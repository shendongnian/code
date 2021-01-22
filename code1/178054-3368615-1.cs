    double sum = 0.0;
    Parallel.ForEach(myCollection,
        () => // Initializer
        {
            return 0D;
        },
        (item, state, subtotal) => // Loop body
        {
            return subtotal += ComplicatedFunction(item);
        },
        (subtotal) => // Accumulator
        {
            lock (myCollection)
            {
              sum += subtotal;
            }
        });
