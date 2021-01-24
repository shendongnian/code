    public class GameState : IGameState
    {
        public List<PlayerModel> Players { get; set; }
        
        IReadOnlyList<PlayerModel> IReadOnlyGameState.Players => Players;
    }
