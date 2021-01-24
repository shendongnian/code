    class EvolutionHandler
    {
        public IEvolable Evolable { get; set; }
        public void TryEvolveCharacter()
        {
            if (Evolable is ILevelable levelable && levelable.Level > 10)
            {
                Evolable.IncreaseEvolution(1);
            }
            else if (someCondition)
            {
                Evolable.IncreaseEvolution(1);
            }
        }
    }
