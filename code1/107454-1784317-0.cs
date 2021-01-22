    internal class Program {
        private static void Main(string[] args) {
            foreach (var combination in AllCombinations(new[] { 1, 2, 3 })) {
                Console.WriteLine(string.Join("", combination.Select(item => item.ToString()).ToArray()));
            }
        }
        private static IEnumerable<IEnumerable<T>> AllCombinations<T>(IList<T> elements) {
            if (elements.Count == 1) yield return new[] { elements[0] };
            else {
                foreach (var element in elements) {
                    var remainingElements = elements.ToList();
                    remainingElements.Remove(element);
                    foreach (var combination in AllCombinations(remainingElements)) {
                        yield return (new List<T> { element }).Concat<T>(combination);
                    }
                }
            }
        }
    }
