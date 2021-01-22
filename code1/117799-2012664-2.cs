    public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T> subjects, Func<T, IEnumerable<T>> selector)
    {
        const int MaxFrameCount = 100000;
        Debug.Assert(new StackTrace().FrameCount < MaxFrameCount);
        // Stop if subjects are null or empty
        if(subjects == null || !subjects.Any())
            yield break;
    
        // For each subject
        foreach(var subject in subjects)
        {
            // Yield it
            yield return subject;
    
            // Then yield all its decendants
            foreach (var decendant in SelectRecursive(selector(subject), selector))
                yield return decendant;
        }
    }
