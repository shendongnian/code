    using System;
    using System.Linq;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] stringArray = new[] { // you get this array from Textbox.Lines
                "one line of text",
                "second line with more text",
                "short line",
                "very long line with text and more text",
                "very long line with text and more text" };
    
            var sorted = stringArray
                .Select((text, index) => new { Index = index, Text = text, Length = text.Length }) // create anonymous type
                .OrderByDescending(ano => ano.Length)
                .ToList(); // order by lenght descending
            var maxLength = sorted.Max(ano => ano.Length); // get max length
    
            var maxOnes = sorted.Where(ano => ano.Length == maxLength);
    
            foreach (var ano in sorted)
                Console.WriteLine($"{ano.Index} has length {ano.Length} and text of '{ano.Text}'");
    
            Console.WriteLine($"The longest ones had indexes: {string.Join(",", maxOnes.Select(ano => ano.Index))}");
            Console.ReadLine();
        }
    }
    
