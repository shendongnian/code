    using Humanizer;
    using static System.Console;
    
    namespace HumanizerConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                WriteLine("AwaitingFeedback".Humanize());
                WriteLine("PascalCaseInputStringIsTurnedIntoSentence".Humanize());
                WriteLine("Underscored_input_string_is_turned_into_sentence".Humanize());
                WriteLine("Can_return_title_Case".Humanize(LetterCasing.Title));
                WriteLine("CanReturnLowerCase".Humanize(LetterCasing.LowerCase));
            }
        }
    }
