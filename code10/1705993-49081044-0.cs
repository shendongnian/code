    static class ExtensionMethods
    {
        static public void SetHealth(this ProgressBar control, Hero hero)
        {
            ProgressBarHeroHealth1.Max = hero.MaxHealth;
            ProgressBarHeroHealth1.Value = hero.Health;
        }
    }
