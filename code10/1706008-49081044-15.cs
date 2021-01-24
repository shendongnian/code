    class HeroHealthBar : ProgressBar
    {
        protected readonly Hero _hero;
        public HeroHealthBar(Hero hero) : base()
        {
            _hero = hero;
            hero.HealthChanged += this.Hero_HealthChanged;
        }
        public void Hero_HealthChanged(object sender, EventArgs e)
        {
            this.Max = _hero.MaxHealth;
            this.Value = _hero.Health;
        }
    }
        
