    for (int i = 0; i < maxDirections; i++)
    {
        Debug.Log("gimme tsMoves "+tSpossibleMoves[i].Count +  " from " + this);
        possibleAttacks[i] = new List<T>(tSpossibleAttacks[i]);
        tSpossibleAttacks[i].Clear();
        possibleAttacksInactive[i] = new List<U>(tSpossibleAttacksInactive[i]);
        tSpossibleAttacksInactive[i].Clear();
        possibleAttackIndicators[i] = new List<V>(tSpossibleAttackIndicators[i]);
        tSpossibleAttackIndicators[i].Clear();
        possibleMoves[i] = new List<X>(tSpossibleMoves[i]);
        tSpossibleMoves[i].Clear();
        
        Debug.Log($"Gimme moves(1), i={i}: {possibleMoves[i].Count} from {this}");
        Debug.Log($"Gimme moves(2)  i={i}: {tpossibleMoves[i].Count} from {this}");
    }
