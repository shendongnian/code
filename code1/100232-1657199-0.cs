    class WellBehavedRandomOpponent : IBattleShipOpponent
    {
        Rand rand = new Rand();
        List<Point> guesses;
        int nextGuess = 0;
        public void PlaceShips(IEnumerable<Ship> ships)
        {
            BoardView<bool> board = new BoardView<bool>(BoardSize);
            var AllOrientations = new[] {
                ShipOrientation.Horizontal,
                ShipOrientation.Vertical };
    
            foreach (var ship in ships)
            {
                while (!ship.IsPlaced)
                {
                    var l = rand.Pick(board.Select(c => c.Location));
                    var o = rand.Pick(AllOrientations);
                    if (ship.IsLegal(ships, BoardSize, l, o))
                        ship.Place(l, o);
                }
            }
        }
        
        public void NewGame(Size size, TimeSpan timeSpan)
        {
            var board = new BoardView<bool>(size);
            this.guesses = new List<Point>(
                board.Select(x => x.Location).Shuffle(rand));
            nextGuess = 0;
        }
        public System.Drawing.Point GetShot()
        {
            return guesses[nextGuess++];
        }
        // empty methods left out 
    }
