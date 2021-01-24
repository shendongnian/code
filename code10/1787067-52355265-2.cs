    public class PlayersTurn
    {
        public int PlayerMoveAttempt { get; set; }
        public int PlayerMove{ get; set; }
        public int MatchAmount{ get; set; }
        public PlayersTurn(int playerMoveAttempt, int playerMove, int matchAmount)
        {
            this.PlayerMoveAttempt = playerMoveAttempt;
            this.PlayerMove = playerMove;
            this.MatchAmount = matchAmount;
        }
    
        public void PlayerTurnMove()
        {
            while (this.playerMoveAttempt < 1 || this.playerMoveAttempt > 3)
            {
                Console.WriteLine("Please take between 1 and 3 matches");
                this.playerMoveAttempt = Convert.ToInt32(Console.ReadLine());
            }    
        }
    }
