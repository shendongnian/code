    static class test
        {
            public static void RemAll<T>(this List<Object> self, T t) where T : Type
            {
                self.RemoveAll(x => x.GetType()==t);
            }
        }
