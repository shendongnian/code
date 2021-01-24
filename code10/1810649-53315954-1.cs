    class TeamFitness : IFitness
    {
        private readonly List<Player> _players;
        private readonly int _startTeamValue;
        private List<Player> _selected;
        public TeamFitness(List<Player> players, int startTeamValue)
        {
            _players = players;
            _startTeamValue = startTeamValue;
        }
        public double Evaluate(IChromosome chromosome)
        {
            double f1 = 9;
            _selected = new List<Player>();
            var indexes = new List<int>();
            foreach (var gene in chromosome.GetGenes())
            {
                indexes.Add((int)gene.Value);
                _selected.Add(_players[(int)gene.Value]);
            }
            if (indexes.Distinct().Count() < chromosome.Length)
            {
                return int.MinValue;
            }
            var sumMarketValue = _selected.Sum(s => s.MarketValue);
            var targetValue = _startTeamValue;
            if (sumMarketValue < targetValue)
            {
                f1 = targetValue - sumMarketValue;
            }else if (sumMarketValue > targetValue)
            {
                f1 = sumMarketValue - targetValue;
            }
            else
            {
                f1 = 0;
            }
            var keeperCount = _selected.Count(s => s.PlayerPosition == PlayerPosition.Keeper);
            var strikerCount = _selected.Count(s => s.PlayerPosition == PlayerPosition.Striker);
            var defCount = _selected.Count(s => s.PlayerPosition == PlayerPosition.Defender);
            var middleCount = _selected.Count(s => s.PlayerPosition == PlayerPosition.Midfield);
            var factor = 0;
            var penaltyMoney = 10000000;
            if (keeperCount > 2)
            {
                factor += (keeperCount - 2) * penaltyMoney;
            }
            if (keeperCount == 0)
            {
                factor += penaltyMoney;
            }
            if (strikerCount < 2)
            {
                factor += (2 - strikerCount) * penaltyMoney;
            }
            if (middleCount < 4)
            {
                factor += (4 - middleCount) * penaltyMoney;
            }
            if (defCount < 4)
            {
                factor += (4 - defCount) * penaltyMoney;
            }
            
            return 1.0 - (f1 + factor);
        }
    }
