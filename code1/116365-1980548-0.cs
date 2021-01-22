    static class ListExtensions {
        public static void AlterList<T>(this List<T> list, Func<T, T> selector) {
            for(int index = 0; index < list.Count; index++) {
                list[index] = selector(list[index]);
            }
        }
    }
