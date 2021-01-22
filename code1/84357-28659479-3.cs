    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Test
    {
	    public static void Main()
	    {
            var randomCharacters = GetRandomCharacters(8, true);
            Console.WriteLine(new string(randomCharacters.ToArray()));
	    }
        private static List<char> getAvailableRandomCharacters(bool includeLowerCase)
        {
            var integers = Enumerable.Empty<int>();
            integers = integers.Concat(Enumerable.Range('A', 26));
            integers = integers.Concat(Enumerable.Range('0', 10));
            if ( includeLowerCase )
                integers = integers.Concat(Enumerable.Range('a', 26));
            return integers.Select(i => (char)i).ToList();
        }
        public static IEnumerable<char> GetRandomCharacters(int count, bool includeLowerCase)
        {
            var characters = getAvailableRandomCharacters(includeLowerCase);
            var random = new Random();
            var result = Enumerable.Range(0, count)
                .Select(_ => characters[random.Next(characters.Count)]);
            return result;
        }
    }
