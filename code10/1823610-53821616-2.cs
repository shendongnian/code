    public class Player : PictureBox
    {
        public int id { get; set; }
        public string name { get; set; }
        public int currentGameSquare { get; set; }
        //etc, etc
    }
    public class GameSquare : PictureBox
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        //etc..etc.     
    }
     public class Game
    {
       private List<GameSquare> gameBoard;
       private Player p;
        //you're going to populate square values and title somewhere else in your code.
        Dictionary<string, int> squareValues = new Dictionary<string, int>();
        public Game()
        {
            gameBoard = new List<GameSquare>();
            p = new Player();
            GenerateGameBoard(40);
        }
       public void GenerateGameBoard(int numSquares)
       {
           for (int i = 0; i < gameBoard.Count(); i++)
            {
                GameSquare s = new GameSquare()
                {
                    Id = i,
                    Name = gameBoard.ElementAt(i).Key
                    Value = gameBoard.ElementAt(i).Value
                    Location = new Point(someX, someY)  //however your assigning the board layout
                    //Assign the rest of the properties however you're doing it
                };
                gameBoard.Add(s);
            }
        }
    }
