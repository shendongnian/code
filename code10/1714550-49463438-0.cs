    public class PlayerData
    {
        public int PlayerID { get; set; }
    }
    public class Player : PlayerData
    {
        public Player(PlayerData pd) : base()
        {
            this.PlayerID = pd.PlayerID;
        }
    }
