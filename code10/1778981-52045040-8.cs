    public class Player
    {
        public string Name { get; set; }
        public ConsoleColor Color { get; set; }
        public void Speak(string speech)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(speech);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
