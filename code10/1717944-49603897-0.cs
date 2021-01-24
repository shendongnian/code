    class MammalFactory : IOrganismSubFactory
    {
        public Organism Create(Observation observation)
        {
            if (observation.NumLegs != 4) return null;
            return new Mammal(obs);
        }
    }
