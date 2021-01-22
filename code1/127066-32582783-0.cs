    public interface IPlayer 
    {
       string Name { get; set; }
    }
    public class Player : IPlayer 
    {
       string Name { get; set; }
    }
    IPlayer playerDto = player as IPlayer;
    Player player = Player(playerDto);
