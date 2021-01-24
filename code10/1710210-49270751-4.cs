    public class DataInteger
    {
    	[JsonProperty(PropertyName = "totalUnitsKilled ")]
    	public int totalUnitsKilled { get; set; }
    	public int totalTitansKilled { get; set; }
    	public int totalTimePlayed { get; set; }
    	[JsonProperty(PropertyName = "substrate-TotalGamesPlayed")]
    	public int SubstrateTotalGamesPlayed { get; set; }
    	[JsonProperty(PropertyName = "phC-TotalGamesPlayed")]
    	public int PHCTotalGamesPlayed { get; set; }
    	public int lastReplayVersion { get; set; }
    	public int replayUploadedCount { get; set; }
    }
    
    public class RootObject
    {
    	public string personaLadderId { get; set; }
    	public int rank { get; set; }
    	public string personaId { get; set; }
    	public string personaName { get; set; }
    	public string avatarUrl { get; set; }
    	public string avatarUrlSmall { get; set; }
    	public string avatarUrlMedium { get; set; }
    	public string avatarUrlLarge { get; set; }
    	public string ladderType { get; set; }
    	public string ladderId { get; set; }
    	public string seasonId { get; set; }
    	public int bracketId { get; set; }
    	public string bracketName { get; set; }
    	public int rankingScore { get; set; }
    	public int secondaryScore { get; set; }
    	public int ruleTypeId { get; set; }
    	public int wins { get; set; }
    	public int losses { get; set; }
    	public int ties { get; set; }
    	public int tieStreak { get; set; }
    	public int winStreak { get; set; }
    	public int lossStreak { get; set; }
    	public int longestTieStreak { get; set; }
    	public int longestWinStreak { get; set; }
    	public int longestLossStreak { get; set; }
    	public int bracketMaxScore { get; set; }
    	public int bracketScore { get; set; }
    	public DateTime updateDate { get; set; }
    	public int totalMatchesPlayed { get; set; }
    	public DataInteger dataInteger { get; set; }
    }
