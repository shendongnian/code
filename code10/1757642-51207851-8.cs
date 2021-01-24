    public class Interface
    {
        PlayGame play = new PlayGame();
        public void GenMap()
        {
            string NewLine;
            Console.Clear();
            Console.WriteLine("    | A | B | C |");
            Console.WriteLine("-----------------");
            //new PlayGame(); (WHY??)
            for(int i=0;i<3;i++)
            {
                NewLine = System.String.Format("| {0} | {1} | {2} | {3} |",
                    i+1, 
                    /*play.*/PlayerToIcon(/*play, */0, 0), 
                    /*play.*/PlayerToIcon(/*play, */0, 1), 
                    /*play.*/PlayerToIcon(/*play, */0, 2));
                Console.WriteLine(/*(string)NewLine*/);
                Console.WriteLine("----------------");
            }
        }
        public string PlayerToIcon(int LocA, int LocB)
        {
            int[,] Board = play.Board;
            int LocData = (Board[LocA, LocB]);
            if (LocData == 0) { return " "; }
            else if (LocData == 1) { return "X"; }
            else { return "O"; }
        }
    }
