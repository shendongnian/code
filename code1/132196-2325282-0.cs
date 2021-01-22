        public static void TrimList(this List<string> list) {
            while (string.Empty == list[0]){
                list.RemoveAt(0);
            }
            while (string.Empty == list[list.Count - 1]) {
                list.RemoveAt(list.Count - 1);
            }
        }
