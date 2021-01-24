    public class PlayerService
    {
        private IPlayerRepository _playerRepository = null;
        public IPlayerRepository PlayerRepository
        {
            get { return _playerRepository ?? (_playerRepository = new PlayerRepository()); }
            set { _playerRepository = value; }
        }
       
        // ...
    }
