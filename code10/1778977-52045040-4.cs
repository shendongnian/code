    public class Player
    {
        public string Name { get; set; }
        public ConsoleColor Color { get; set; }
        public void Speak(string speach)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(speach);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
