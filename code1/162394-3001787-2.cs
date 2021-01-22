        [Flags]
        private enum Shot
        {
            Whisky = 1,
            Absynthe = 2,
            Pochin = 4,
            BrainEraser = Whisky | Absynthe | Pochin
        }
        [Test]
        public void Test()
        {
            Shot myCocktail = Shot.Absynthe | Shot.Whisky;
            Shot randomShotInCocktail = GetRandomShotFromCocktail(myCocktail);
        }
        private static Shot GetRandomShotFromCocktail(Shot cocktail)
        {
            Random random = new Random();
            Shot[] shots = (Shot[])Enum.GetValues(typeof(Shot));
            int flagCount = Enum.GetValues(typeof(Shot)).
                 Cast<Shot>().
                 Select(x => cocktail.HasFlag(x)).
                 Count();
            while (true)
            {
                foreach (Shot shot in shots)
                {
                    if (cocktail.HasFlag(shot) && random.Next(0, flagCount) == 1)
                    {
                        return shot;
                    }
                }
            }
        }
