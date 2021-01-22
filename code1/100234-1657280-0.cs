    class Crossfire : ShootingStrategy
    {
        BoardView<OpponentsBoardState> board= 
            new BoardView<OpponentsBoardState>(new Size(10,10));
        Rand rand = new Rand();
        
        public override void NewGame(Size size, TimeSpan timeSpan)
        {
            base.NewGame(size, timeSpan);
            this.board = new BoardView<OpponentsBoardState>(size);            
        }
        protected virtual Point PickWhenNoTargets()
        {
            return rand.Pick(board.Where(
                c => c.Data == OpponentsBoardState.Unknown)).Location;
        }
        public override System.Drawing.Point GetShot()
        {
            var target = board.Where(
                     c => c.Data == OpponentsBoardState.Hit)
                .SelectMany(c => c.Neighbours())
                .Where(c => c.Data == OpponentsBoardState.Unknown)
                .RandomOrDefault(rand);
            if (target == null)
                return PickWhenNoTargets();
            return target.Location;
        }
        public override void ShotHit(Point shot, bool sunk)
        {
            board[shot] = OpponentsBoardState.Hit;
        }
        public override void ShotMiss(Point shot)
        {
            board[shot] = OpponentsBoardState.Miss;
        }
    }
