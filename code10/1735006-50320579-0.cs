    public class Encounter
    {
        Player player;
        IEnumerable<Enemy> enemies;
        public Encounter(Player player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            this.player = player;
            enemies = new List<Enemy>();
        }
    }
