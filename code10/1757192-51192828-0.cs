    if (messung.Any()) // same logic than `if (messung.Count > 0)` as @Matthew Watson said
    {
        // by the way linq can handle sum
        ergebnis = messung.Sum(x => x.Messwert) / messung.Count;
        // in fact you can go further, linq includes Average
        ergebnis = messung.Average(x => x.Messwert);
    }
