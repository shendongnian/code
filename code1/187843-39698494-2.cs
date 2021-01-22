    class Program {
        static void Main(string[] args) {
            // write to location 0,0
            LowLevelConsole.Write("Some test text", CharacterAttribute.BACKGROUND_BLUE | CharacterAttribute.FOREGROUND_RED, 0, 0);
            // write to location 5,10
            LowLevelConsole.Write("another test at a different location", 
                CharacterAttribute.FOREGROUND_GREEN | CharacterAttribute.FOREGROUND_BLUE,
                5, 10);
            Console.ReadLine();            
        }
    }
