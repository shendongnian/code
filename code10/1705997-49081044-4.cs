    class HeroHealthBar : ProgressBar
    {
        protected readonly Hero _hero;
        public HeroHealthBar(Hero hero) : base()
        {
            _hero = hero;
            hero.HealthChanged += this.OnHealthChanged;
        }
        public void OnHealthChanged(object sender, HealthEventArgs e)
        {
            this.Max = _hero.MaxHealth;
            this.Value = _hero.Health;
        }
    }
        
