    public interface IEffect
    {
        float Duration { get; set; }
        void Do(Player p);
        void Undo(Player p);
    }
    public class ActiveEffect
    {
        public IEffect Effect { get; private set; }
        public float LeftTime;
        public ActiveEffect(IEffect effect)
        {
            Effect = effect;
            LeftTime = effect.Duration;
        }
    }
    public class SpeedBoost : IEffect
    {
        public float Duration { get; set; }
        public SpeedBoost()
        {
            Duration = 4;
        }
        public void Do(Player p)
        {
            p.speed = 40f;
        }
        public void Undo(Player p)
        {
            p.speed = 20f;
        }
    }
