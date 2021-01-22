    public class Tournament
    {
        public virtual Guid Id { get; private set; }
        private readonly ISet<Player> players;
        public Tournament()
        {
            players = new HashedSet<Player>();
        }
        public virtual ISet<Player> Players
        {
            get { return players; }
        }
        public virtual void AddPlayer(Player player)
        {
            players.Add(player);
        }
    }
    public class Player 
    {
        public virtual Guid Id { get; private set; }
        private readonly ISet<Tournament> tournaments;
        public Player()
        {
            tournaments = new HashedSet<Tournament>();
        }
        public virtual ISet<Tournament> Tournaments
        {
            get { return tournaments; }
        }
        public virtual void AddTournament(Tournament tournament)
        {
            tournaments.Add(tournament);
        }
    }
    public class TournamentMap : ClassMap<Tournament>
    {
        public TournamentMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            HasManyToMany<Player>(x => x.Players)
                .AsSet().Access.AsLowerCaseField()
                .Cascade.SaveUpdate();
        }
    }
    public class PlayerMap : ClassMap<Player>
    {
        public PlayerMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            HasManyToMany<Tournament>(x => x.Tournaments)
                .Access.AsLowerCaseField()
                .AsSet()
                .Cascade.SaveUpdate().Inverse();
        }
    }
