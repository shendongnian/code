    public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T> subjects, Func<T, IEnumerable<T>> selector) {
        // Stop if subjects are null or empty 
        if (subjects == null || !subjects.Any())
            return Enumerable.Empty<T>();
        
        // Gather a list of all (selected) child elements of all subjects
        var subjectChildren = subjects.SelectMany(selector);
        // Jump into the recursion for each of the child elements
        var recursiveChildren = SelectRecursive(subjectChildren, selector);
        // Combine the subjects with all of their (recursive child elements).
        // The union will remove any direct parent-child duplicates.
        // Endless loops due to circular references are however still possible.
        return subjects.Union(recursiveChildren);
    }
