    class LocationEngine
    {
        Character _player;
        public LocationEngine(Character player)
        {
            _player = player;
        }
       public void SomeMethod()
       {
           string playerName = _player.Name;
           int playerPoints = _player.Score;
       }
    }
