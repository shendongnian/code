using System;
using System.Text.RegularExpressions;
namespace ConsoleApplication1
{
   /// &lt;summary&gt;
   ///  
   ///  A description of the regular expression:
   ///  
   ///  Match expression but don't capture it. [^|\s+]
   ///      Select from 2 alternatives
   ///          Beginning of line or string
   ///          Whitespace, one or more repetitions
   ///  [1]: A numbered capture group. [(\w+)(?:\s+|$)]
   ///      (\w+)(?:\s+|$)
   ///          [2]: A numbered capture group. [\w+]
   ///              Alphanumeric, one or more repetitions
   ///          Match expression but don't capture it. [\s+|$]
   ///              Select from 2 alternatives
   ///                  Whitespace, one or more repetitions
   ///                  End of line or string
   ///  [3]: A numbered capture group. [\1|\2], one or more repetitions
   ///      Select from 2 alternatives
   ///          Backreference to capture number: 1
   ///          Backreference to capture number: 2
   ///  
   ///
   /// &lt;/summary&gt;
   class Class1
	{
		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		static void Main(string[] args)
		{
			Regex regex = new Regex(
				"(?:^|\\s+)((\\w+)(?:\\s+|$))(\\1|\\2)+",
				RegexOptions.IgnoreCase
				| RegexOptions.Compiled
				);
			string str = "cats cats cats and dogs dogs dogs and cats cats and dogs dogs";
			string regexReplace = " $1";
			Console.WriteLine("Before :" + str);
			str = regex.Replace(str,regexReplace);
			Console.WriteLine("After :" + str);
		}
	}
}
