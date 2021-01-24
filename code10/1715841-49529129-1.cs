    using System;
    using System.Text.RegularExpressions;
    public class Example
    {
        public static void Main()
        {
            string input = @"<expr><op><expr>
    (<expr><op><expr>)
    <pre_op>(<expr>)
    (<expr>)<pre_op>(<expr>)";
    
             Regex rxBalanced = new Regex(
                @"(?<B>\()+[^()]+(?<-B>\))(?(B)(?!))|(?<A><)+[^<>]+(?<-A>>)+(?(A)(?!))",
                RegexOptions.Multiline
                | RegexOptions.CultureInvariant
                | RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled
            );
            Regex rxTokens = new Regex(
                @"\(|<.*?>|\)",
                RegexOptions.Multiline
                | RegexOptions.CultureInvariant
                | RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled
            );
    
            foreach (Match match in rxBalanced.Matches(input))
            {
                foreach (Match token in rxTokens.Matches(match.Value))
                {
                    Console.WriteLine(token.Value);
                }
            }
        }
    }
