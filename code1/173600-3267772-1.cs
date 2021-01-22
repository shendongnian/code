     public class MoveCommand {
        public Player CurrentPlayer { get; set; } 
        public Level CurrentLevel { get; set; }
        public void Execute() { ... }
     }
     public static void Main() {
         var cmd = new MoveCommand();
         cmd.CurrentPlayer = currentPlayer;
         cmd.CurrentLevel = currentLevel;
         cmd.Execute();
    }
