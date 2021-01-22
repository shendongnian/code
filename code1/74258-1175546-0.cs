    public class GameRound{
        public DateTime Date { get; set; }
        public String Name { get; set; }
        public Boolean DidCheat { get; set; }
    
        public void Print()
        {
            Console.WriteLine(String.Format("Date:{0}, Name:{1}, Cheated: {2}", Date, Name, DidCheat));
        }
    }
    
    public class GameRounds : List<GameRound>{
       public void Add(DateTime date, string name, bool didCheat) {
                    this.Add(new GameRound { Date = date, Name = name, DidCheat = didCheat });
       }
    }
    
    public static void Play(){
                var gameRounds = new GameRounds();
                //Round 1
                gameRounds.Add(DateTime.Today, "ABC", false);
                //Round 2
                gameRounds.Add(DateTime.Today, "DEF", true);
    
                //Print
                foreach (var gameRound in gameRounds)
                {
                    gameRound.Print();
                }
     }
