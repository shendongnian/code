    for (int i = 0; i < maxDirections; i++)
    {
        Debug.Log("gimme tsMoves "+tSpossibleMoves[i].Count +  " from " + this);
        possibleAttacks[i] = tSpossibleAttacks[i];
        tSpossibleAttacks[i] = new List<T>;
        possibleAttacksInactive[i] = tSpossibleAttacksInactive[i];
        tSpossibleAttacksInactive[i] = new List<U>();
        possibleAttackIndicators[i] = tSpossibleAttackIndicators[i];
        tSpossibleAttackIndicators[i] = new List<V>();
        possibleMoves[i] = tSpossibleMoves[i];
        tSpossibleMoves[i] = new List<Z>();
        
        Debug.Log($"Gimme moves(1), i={i}: {possibleMoves[i].Count} from {this}");
        Debug.Log($"Gimme moves(2)  i={i}: {tpossibleMoves[i].Count} from {this}");
    }
