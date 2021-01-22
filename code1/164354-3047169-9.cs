    public Level Level { get; set; }
    public string RankName { get; set; }
    public MyRank(int points)
    {
        Level = GetLevel(points);
        RankName = GetRankName(Level);
    }
