    static void Main(string[] args)
            {
                PlayerData pd = new PlayerData();
                IChannelHandlerContext chanelHandlerContext = new ChannelHandlerContext();
                Player p = new Player(chanelHandlerContext, pd);
                Console.WriteLine(p);
            }
    
            interface IChannelHandlerContext
            {
    
            }
    
            class ChannelHandlerContext : IChannelHandlerContext
            {
    
            }
    
            class PlayerData
            {
    
            }
    
            class Player : PlayerData
            {
                public Player(IChannelHandlerContext context, PlayerData pd) : base()
                {
                }
            }
