    class Program
    {
        static void Main()
        {
            string playerToIcon = new PlayGame().PlayerToIcon(new PlayGame(), 0, 1); 
        }
    }
    public class PlayGame
    {
        public int[,] Board = new int[3, 3]
        {          //A  B C
                {0,0,0 }, // 1
                {0,0,0 }, // 2
                {0,0,0 }  // 3
        };
        public string PlayerToIcon(PlayGame play, int LocA, int LocB)
        {
            int[,] Board = play.Board;
            int LocData = (Board[LocA, LocB]);
            if (LocData == 0)
            {
                return "";
            }
            else if (LocData == 1)
            {
                return "X";
            }
            else
            {
                return "0";
            }
        }
    }
