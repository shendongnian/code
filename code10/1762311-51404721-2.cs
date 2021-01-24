    public interface IPlayerProfile
    {
         int PlayerScore { get; }
    }
    public class Player : IPlayerProfile
    {
        public int PlayerScore { get; } = 250;
    }
    public class PlayersManager
    {
        public Add(IPlayerProfile profile)
        {
            // Use profile.PlayerScore
        }
    }
