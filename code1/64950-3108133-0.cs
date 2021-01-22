    System.Collections.BitArray falses = new System.Collections.BitArray(100000, false);
    System.Collections.BitArray trues = new System.Collections.BitArray(100000, true);
    
    // Now both contain only true values.
    falses.And(trues);
