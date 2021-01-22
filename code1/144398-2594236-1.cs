    public class RegExpression {
      public static void Example(string input, string ignore, string find)
      {
         string output = string.Format("Input: {1}{0}Ignore: {2}{0}Find: {3}{0}{0}", Environment.NewLine, input, ignore, find);
         if (SanitizeText(input, ignore).ToString().Contains(SanitizeText(find, ignore)))
            Console.WriteLine(output + "was matched");
         else
            Console.WriteLine(output + "was NOT matched");
         Console.WriteLine();
      }
      public static string SanitizeText(string input, string ignore)
      {
         Regex reg = new Regex("[^" + ignore + "]");
         StringBuilder newInput = new StringBuilder();
         foreach (Match m in reg.Matches(input))
         {
            newInput.Append(m.Value);
         }
         return newInput.ToString();
      }
