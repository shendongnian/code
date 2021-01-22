    public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T> subjects, Func<T, IEnumerable<T>> selector) {
        // Stop if subjects are null or empty 
        if (subjects == null || !subjects.Any())
            return Enumerable.Empty<T>();
        
        // Select the subjects and their underlying subjects recursively
        return subjects.Union(SelectRecursive(subjects.SelectMany(selector), selector));
    }
