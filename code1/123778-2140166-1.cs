    static class IEnumerableStringExtensions {
        public static IEnumerable<string> GetWords(this IEnumerable<string> lines) {
            foreach (string line in lines) {
                foreach (string word in line.Split(' ')) {
                    yield return word;
                }
            }
        }
    }
