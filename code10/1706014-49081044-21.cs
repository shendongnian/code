    static class ExtensionMethods
    {
        static public void SetHealth(this ProgressBar control, Hero hero)
        {
            control.Max = hero.MaxHealth;
            control.Value = hero.Health;
        }
    }
