    public bool IsSameOrSubclass(Type potentialBase, Type potentialDescendant)
    {
        return potentialDescentant.IsSubclassOf(potentialBase)
               || potentialDescendant == potentialBase;
    }
