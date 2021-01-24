    class Hero
    {
        public event EventHandler HealthChanged;
        public void SetHealth(int current, int max)
        {
            _health = current;
            _maxHealth = max;
           OnHealthChanged();
        }
        protected void OnHealthChanged()
        {
            if (HealthChanged != null) HealthChanged(this, EventArgs.Empty);
        }
    }
