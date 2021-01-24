    public class Program
    {
        private static readonly Random Rnd = new Random();
        private static string GetRandomItemAndRemoveIt(IList<int> items)
        {
            if (items == null || items.Count == 0) return string.Empty;
            var randomItem = items[Rnd.Next(items.Count)];
            items.Remove(randomItem);
            // The PadRight method will ensure each string is at least two characters wide
            return randomItem.ToString().PadRight(2, ' ');
        }
