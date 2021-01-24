    public class Player
    {
        public event Action<int> TeamChanged;
        private int team;
        public int Team 
        {
            get { return team; }
            set 
            {
                if (value != team) {
                    team = value;
                    OnTeamChanged(team); } 
            } 
        }
        public Player(int startingTeam)
        {
            team = startingTeam; 
        }
        private void OnTeamChanged(int newTeam)
        {
            TeamChanged?.Invoke(team);
        }
    }
