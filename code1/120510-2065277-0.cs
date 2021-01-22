    public interface IParser
    {
        object Parse(string input);
    }
    public interface IParser<T> : IParser
    {
        new T Parse(string input);
    }
    public class MyParser : IParser<MyObject>
    {
        #region IParser<MyObject> Members
        public MyObject Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException("input");
            if (input.Length < 3)
                throw new ArgumentOutOfRangeException("input too short");
            return new MyObject()
            {
                Field1 = input.Substring(0, 1),
                Field2 = input.Substring(1, 1),
                Field3 = input.Substring(2, 1)
            };
        }
        object IParser.Parse(string input)
        {
            return this.Parse(input);
        }
        #endregion
    }
    public class MyObject
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
    }
    public static class ToolKit
    {
        public static Dictionary<string, TResult> ReadFile<TParser, TResult>(
                this string fileName)
            where TParser : IParser<TResult>, new()
            where TResult : class
        {
            return fileName.AsLines()
                           .ReadFile<TParser, TResult>();
        }
        public static Dictionary<string, TResult> ReadFile<TParser, TResult>(
                this IEnumerable<string> input)
            where TParser : IParser<TResult>, new()
            where TResult : class
        {
            var parser = new TParser();
            var ret = input.ToDictionary(
                            line => line, //key
                            line => parser.Parse(line)); //value
            return ret;
        }
        public static IEnumerable<string> AsLines(this string fileName)
        {
            using (var reader = new StreamReader(fileName))
                while (!reader.EndOfStream)
                    yield return reader.ReadLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var result = new[] { "123", "456", "789" }
                .ReadFile<MyParser, MyObject>();
            var otherResult = "filename.txt".ReadFile<MyParser, MyObject>();
        }
    }
