    class DeathsKills
    {
        public int NumDeaths;
        public int NumKills;
    }
    IDictionary<int, DeathsKills> playerDeathKills = new Dictionary(...);
    public void AddKill(int killerId, int victimId)
    {
        DeathKills killer;
        if (!playerDeathKills.TryGetValue(killerId, out killer)) {
            killer = new DeathKills();
            playerDeathKills.Add(killerId, killer);
        }
        killer.NumKills ++;
        DeathKills victim;
        if (!playerDeathKills.TryGetValue(victimId, out victim)) {
            victim = new DeathKills();
            playerDeathKills.Add(victimId, victim);
        }
        victim.NumDeaths ++;
    }
