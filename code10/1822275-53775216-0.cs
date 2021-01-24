    // Signatures for up to 4 fields.
    public static class EqualityUtility
    {
        public static int GetHashCode<T1>(T prop1);
        public static int GetHashCode<T1, T2>(T prop1, T2 prop2);
        public static int GetHashCode<T1, T2, T3>(T prop1, T2 prop2, T3 prop3);
        public static int GetHashCode<T1, T2, T3, T4>(T prop1, T2 prop2, T3 prop3, T4 prop4);
        public static bool OtherIsNotNull<T>(T other) where T : class => !(other is null);
        public static bool Equals<T1>(T1 obj1prop1, T1 obj2prop1);
        public static bool Equals<T1, T2>(T1 obj1prop1, T1 obj2prop1, T2 obj1prop2, T2 obj2prop2);
        public static bool Equals<T1, T2, T3>(T1 obj1prop1, T1 obj2prop1, T2 obj1prop2, T2 obj2prop2, T3 obj1prop3, T3 obj2prop3);
        public static bool Equals<T1, T2, T3, T4>(T1 obj1prop1, T1 obj2prop1, T2 obj1prop2, T2 obj2prop2, T3 obj1prop3, T3 obj2prop3, T4 obj1prop4, T4 obj2prop4);
    }
