    IEnumerable<String> original = GetOriginalEnumerable();
    IEnumerator<String>[] newOnes = original.GetEnumerator().AlmostClone(2);
                                                             ^- extension method
                                                             produce 2
                                                             new enumerators
