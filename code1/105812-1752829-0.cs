    List<Player> Players;
    List<Round> Rounds;
    List<List<RoundScore>> Scores;
    List<RoundScore> GetRoundScores(Round round)
    {
        return Scores[round.Index];
    }
   
    IList<RoundScore> GetRoundScores(Player player)
    {
        return new PlayerScoreList(Scores, player.Index); // or better yet, cache this
    }
    public class PlayerScoreList : IList<RoundScore>
    {
        private List<List<RoundScore>> _scores;
        private int _playerIndex;
        public RoundScore this[int index]
        {
            get
            {
                return _scores[_playerIndex][index];
            }
            set
            {
                _scores[_playerIndex][index] = value;
            }
        }
        public PlayerScoreList(List<List<RoundScore>> scores, int playerIndex)
        {
            _scores = scores;
            _playerIndex = playerIndex;
        }
        public void Add(RoundScore item)
        {
            throw new NotSupportedException();
        }
        public void Clear()
        {
            throw new NotSupportedException();
        }
        public bool Contains(RoundScore item)
        {            
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
        public int Count
        {
            get { return _scores[0].Count; }
        }
        public IEnumerator<RoundScore> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }
        // ... more methods
    }
