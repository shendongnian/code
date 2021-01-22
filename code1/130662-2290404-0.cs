    public static class TextReaderExtensions
    {
        public static IEnumerable<string> Lines(this TextReader reader)
        {
            string line;
            while((line = reader.ReadLine()) != null) yield return line;
        }
    }
