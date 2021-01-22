        public static void TrimList(this List<string> list) {
            while (0 != list.Count && string.IsNullOrEmpty(list[0])) {
                list.RemoveAt(0);
            }
            while (0 != list.Count && string.IsNullOrEmpty(list[list.Count - 1])) {
                list.RemoveAt(list.Count - 1);
            }
        }
