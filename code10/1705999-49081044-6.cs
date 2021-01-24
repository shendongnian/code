    public class HealthBar : ProgressBar
    {
        public void SetHealth(Hero hero)
        {
            this.Max = hero.MaxHealth;
            this.Value = hero.Health;
        }
    }
