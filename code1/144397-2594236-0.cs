    public class RegExpression {
      public static void Example(string input, string ignore, string find)
      {
         Regex reg = new Regex("[^" + ignore + "]");
         StringBuilder newInput = new StringBuilder();
         foreach (Match m in reg.Matches(input))
         {
            //Append all matches that are not ignored characters
            newInput.Append(m.Value);
         }
         string output = string.Format("Input: {1}{0}Ignore: {2}{0}Find: {3}{0}{0}", Environment.NewLine, input, ignore, find);
         //Search the new input string with your text you wish to find
         if (newInput.ToString().Contains(find))
            Console.WriteLine(output + "was matched");
         else
            Console.WriteLine(output + "was NOT matched");
      }}
