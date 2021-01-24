    class PlayerData
            {
                public PlayerData()
                {
    
                }
    
                public PlayerData(PlayerData pd)
                {
    
                }
            }
    
            class Player : PlayerData
            {
                public Player(IChannelHandlerContext context, PlayerData pd) : base(pd)
                {
                }
            }
