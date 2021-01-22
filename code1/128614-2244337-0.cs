    string foo = "the fish is swimming in the dish";
    string bar = foo.ReplaceAll(
        new[] { "fish", "is", "swimming", "in", "dish" },
        new[] { "dog", "lies", "sleeping", "on", "log" });
    Console.WriteLine(bar);    // the dog lies sleeping on the log
    // ...
    public static class StringExtensions
    {
        public static string ReplaceAll(
            this string source, string[] oldValues, string[] newValues)
        {
            // error checking etc removed for brevity
            string pattern =
                string.Join("|", oldValues.Select(Regex.Escape).ToArray());
            return Regex.Replace(source, pattern, m =>
                {
                    int index = Array.IndexOf(oldValues, m.Value);
                    return newValues[index];
                });
        }
    }
