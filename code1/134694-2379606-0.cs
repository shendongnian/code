        interface IFoo {
                int RowCount();
        }
        static class _FooExtensions {
                public static bool HasAnyRows (this IFoo foo) {
                        return foo.RowCount() > 0;
                }
        }
