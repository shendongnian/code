    public static IEnumerable<T> IntersectNonEmpty<T>(params IEnumerable<T>[] lists)
    {
        return lists.IntersectNonEmpty();
    }
    var intersect = ListsExtensionMethods.IntersectNonEmpty(l1, l2, l3, l4, l5);
