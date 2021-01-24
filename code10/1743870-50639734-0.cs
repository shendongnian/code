    transform.RotateAround(GetAverageLocationOfSoliders(), ...);
    ...
    private static Vector3 GetAverageLocationOfSoliders
    {
        var total = new Vector3();
        foreach(var soldier in Soldiers)
            total += soldier.transform.position;
        return total / Soliders.Count();    // Assuming Soldiers is List<Soldier>
    }
