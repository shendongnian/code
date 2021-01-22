    public class Mob {
        public int MovementRate { get; set; }
    }
    public class MoveBehavior {
        public MoveBehavior(Mob mob) { MobInEffect = mob; }
        public Mob MobInEffect {get; set;}
        // can access MovementRate through MovInEffect.MovementRate
    }
