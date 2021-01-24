    public static class Program
    {
        private static readonly Dictionary<(bool isMsgValid, bool isScoreValid, bool isAgeValid), string> _responses 
            = new Dictionary<(bool, bool, bool), string>()
        {
            [(true, true, true)] = "All para success",
            [(false, false, false)] = "All parameter unsatisfied",
            [(false, true, true)] = "Unmatching message",
            [(true, false, true)] = "Score not satisfied",
            [(true, true, false)] = "Age not satisfied",
            [(false, false, true)] = "Unmatiching message & Score not satisfied",
            [(false, true, false)] = "Unmatiching message & Age not satisfied",
            [(true, false, false)] = "Age & Score not satisfied"
        };
        public static string checkIfConnditions(string msg, int score, int age)
            => _responses[(msg == "hello", score > 20, age < 25)];
        public static void Main(string[] args)
        {
            Console.WriteLine(checkIfConnditions("hello", 45, 20));
            Console.WriteLine(checkIfConnditions("hello", 45, 30));
            Console.WriteLine(checkIfConnditions("hello", 10, 20));
            Console.WriteLine(checkIfConnditions("hello", 10, 30));
            Console.WriteLine(checkIfConnditions("goodbye", 45, 20));
            Console.WriteLine(checkIfConnditions("goodbye", 10, 30));
            Console.WriteLine(checkIfConnditions("goodbye", 45, 20));
            Console.WriteLine(checkIfConnditions("goodbye", 10, 30));
        }
    }
