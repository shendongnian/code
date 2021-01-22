    int _points;
    public MyRank(int points)
    {
        _points = points;
    }
    public RankName { get{ return GetRankName(GetLevel(_points)); } }
    public Level { get{ return GetLevel(_points); } }
