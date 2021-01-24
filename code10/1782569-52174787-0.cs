    public class Player
    {
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
              
        public Action<int> TeamChanged { get; set; }
        public Player(int startingTeam)
        {
            team = startingTeam; 
        }
        private void OnTeamChanged(int newTeam)
        {
            TeamChanged?.Invoke(team);
        }
    }
