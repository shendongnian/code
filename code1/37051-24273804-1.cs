    List<int> tableA = new List<int> { 1, 2, 3 };
    List<int?> tableB = new List<int?> { 3, 4, 5 };
    // Result using both Option 1 and 2. Option 1 would be a better choice
    // if we didn't expect multiple matches in tableB.
    { A = 1, B = null }
    { A = 2, B = null }
    { A = 3, B = 3    }
    List<int> tableA = new List<int> { 1, 2, 3 };
    List<int?> tableB = new List<int?> { 3, 3, 4 };
    // Result using Option 1 would be that an exception gets thrown on
    // SingleOrDefault(), but if we use FirstOrDefault() instead to illustrate:
    { A = 1, B = null }
    { A = 2, B = null }
    { A = 3, B = 3    } // Misleading, we had multiple matches.
                        // Which 3 should get selected (not arbitrarily the first)?.
    // Result using Option 2:
    { A = 1, B = null }
    { A = 2, B = null }
    { A = 3, B = 3    }
    { A = 3, B = 3    }    
