	using System;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	namespace TurkishI
	{
		class Program
		{
			static void Main(string[] args)
			{
				var englishI = new UnicodeCharacter('\u0069', "English i");
				var turkishI = new UnicodeCharacter('\u0131', "Turkish i");
				Console.WriteLine("# Lowercase letters");
				Console.WriteLine("Character              | UpperInvariant | UpperTurkish | LowerInvariant | LowerTurkish");
				WriteUpperToConsole(englishI);
				WriteLowerToConsole(turkishI);
				Console.WriteLine("\n# Uppercase letters");
				var uppercaseEnglishI = new UnicodeCharacter('\u0049', "English i");
				var uppercaseTurkishI = new UnicodeCharacter('\u0130', "Turkish i");
				Console.WriteLine("Character              | UpperInvariant | UpperTurkish | LowerInvariant | LowerTurkish");
				WriteLowerToConsole(uppercaseEnglishI);
				WriteLowerToConsole(uppercaseTurkishI);
				Console.ReadKey();
			}
			static void WriteUpperToConsole(UnicodeCharacter character)
			{
				Console.WriteLine("{0,-9} - {1,10} | {2,-14} | {3,-12} | {4,-14} | {5,-12}",
					character.Description,
					character,
					character.UpperInvariant,
					character.UpperTurkish,
					character.LowerInvariant,
					character.LowerTurkish
				);
			}
			static void WriteLowerToConsole(UnicodeCharacter character)
			{
				Console.WriteLine("{0,-9} - {1,10} | {2,-14} | {3,-12} | {4,-14} | {5,-12}",
					character.Description,
					character,
					character.UpperInvariant,
					character.UpperTurkish,
					character.LowerInvariant,
					character.LowerTurkish
				);
			}
		}
		class UnicodeCharacter
		{
			public static readonly CultureInfo TurkishCulture = new CultureInfo("tr-TR");
			public char Character { get; }
			public string Description { get; }
			public UnicodeCharacter(char character) : this(character, string.Empty) {  }
			public UnicodeCharacter(char character, string description)
			{
				if (description == null) {
					throw new ArgumentNullException(nameof(description));
				}
				Character = character;
				Description = description;
			}
			public string EscapeSequence => ToUnicodeEscapeSequence(Character);
			public UnicodeCharacter LowerInvariant => new UnicodeCharacter(Char.ToLowerInvariant(Character));
			public UnicodeCharacter UpperInvariant => new UnicodeCharacter(Char.ToUpperInvariant(Character));
			public UnicodeCharacter LowerTurkish => new UnicodeCharacter(Char.ToLower(Character, TurkishCulture));
			public UnicodeCharacter UpperTurkish => new UnicodeCharacter(Char.ToUpper(Character, TurkishCulture));
			private static string ToUnicodeEscapeSequence(char character)
			{
				var bytes = Encoding.Unicode.GetBytes(new[] {character});
				var prefix = bytes.Length == 4 ? @"\U" : @"\u";
				var hex = BitConverter.ToString(bytes.Reverse().ToArray()).Replace("-", string.Empty);
				return $"{prefix}{hex}";
			}
			public override string ToString()
			{
				return $"{Character} ({EscapeSequence})";
			}
		}
	}
