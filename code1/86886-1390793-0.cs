    public class Choice
    {
        public string Name { get; private set; }
        public int Value { get; private set; }
        public Choice(string name, int value)
        {
            Name = name;
            Value = value;
        }
 
        private static readonly List<Choice> possibleChoices = new List<Choice>
        {
            { new Choice("One", 1) },
            { new Choice("Two", 2) }
        };
        public static List<Choice> GetChoices()
        {
            return possibleChoices;
        }
    }
