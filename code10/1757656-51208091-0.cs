    static void Main()
    {   //This will return the new array with the changed value.
        int[,] BoardArr = new PlayGame().PlayerToIcon(0, 1);
    }
    public class PlayGame
    {
        public int[,] Board = new int[3, 3]
        {          //A  B C
                {0,0,0 }, // 1
                {0,0,0 }, // 2
                {0,0,0 }  // 3
        };
        public int[,] PlayerToIcon(int LocA, int LocB)
        {
            PlayGame play = new PlayGame();
            int[,] Board = play.Board;
            int LocData = (Board[LocA, LocB]);
            if (LocData == 0)
            {
                Board[LocA, LocB] = 1;
                return Board;
            }
            else if (LocData == 1)
            {
                Board[LocA, LocB] = 0;
                return Board;
            }
            else
            {
                return new int[0,0];
            }
        }
    }
