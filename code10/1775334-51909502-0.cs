    // Represents a single event type, e.g. PlayerDamage, PlayerDeath, etc.
    public class Event<THandler> where THandler : Delegate { }
    public delegate void PlayerDamageHandler(Player player, DamageType type);
    public delegate void PlayerDeathHandler(Player player, DeathReason reason);
    public static class Events
    {
        public static Event<PlayerDamageHandler> OnPlayerDamage = new Event<PlayerDamageHandler>();
        public static Event<PlayerDeathHandler> OnPlayerDeath = new Event<PlayerDamageHandler>();
    }
