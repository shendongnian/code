    public static bool HasFive<T>(this IEnumerable<T> subjects) {
        if ( object.ReferenceEquals( subjects, null ) ) { return false; }
    
        return subjects.Count() == 5;
    }
