    public static class AnimalFeeding
    {
        private static Dictionary<Type, Action<Animal>> _feeders 
            = new Dictionary<Type, Action<Animal>>();
        public static void AddFeeder<TAnimal>(Action<TAnimal> feeder) 
            where TAnimal : Animal
        {
            _feeders[typeof(TAnimal)] = a => feeder((TAnimal)a);
        }
        public static void Feed(this Animal a)
        {
            for (Type t = a.GetType(); t != null; t = t.BaseType)
            {
                Action<Animal> feeder;
                if (_feeders.TryGetValue(t, out feeder))
                {
                    feeder(a);
                    return;
                }
            }
            throw new SystemException("No feeder found for " + a.GetType());
        }
    }
