    public sealed class PlayerMap : ClassMap<Player>
    {
    	public PlayerMap()
    	{
    		Id(x => x.ID).GeneratedBy.Native();
    		Map(x => x.Name);
    		HasMany(x => x.Matches).Cascade.SaveUpdate();
    	}
    }
    
    public sealed class MatchMap : ClassMap<Match>
    {
    	public MatchMap()
    	{
    		Id(x => x.ID).GeneratedBy.Native();
    		References(x => x.Player1, "player1_id").NotFound.Ignore().Cascade.None();
    		References(x => x.Player2, "player2_id").NotFound.Ignore().Cascade.None();
    	}
    }
