    public class PlayerService
    {
        private readonly IPlayerRepository _playerRepository = null;
    
        public PlayerService(IPlayerRepository playerRepository)
        {
             _playerRepository = playerRepository ?? throw new ArgumentNullException("playerRepository");
        }
    
    
        public List<Player> GetAllPlayers()
        {
            var players = _playerRepository.GetAllPlayers();
    
            return players;
        }
    }
