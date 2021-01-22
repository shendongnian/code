    const int AMPS = 0; const int CABLE_SIZE = 1; const int TEMP_RATING = 2; // etc.
    var mappings = new Dictionary<int[], int[]>(12 * 13 * 2 * 3 * 2 * 2);
    mappings.Add(
       new int[] { 1, 1, 1, 1, 1, 1 }, // inputs
       new int[] { 1, 2 } //outputs
    );
    // repeat...a lot
    var outputs = mappings.First(inputs => {
       inputs[AMPS] == myAmps
       && inputs[CABLE_SIZE] == myCableSize
       && inputs[TEMP_RATING] == myTempRating
       && // etc
    });
