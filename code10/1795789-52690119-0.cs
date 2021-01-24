    interface IFeature<T> where T : IEquatable<T>
    {
        bool IsMatch(T creatureFeature);
    }
    class FeatureAny<T> : IFeature<T> where T : IEquatable<T>
    {
        public bool IsMatch(T creatureFeature) => true;
    }
    class FeatureSingle<T> : IFeature<T> where T : IEquatable<T>
    {
        private T _feature;
        public FeatureSingle(T feature) => _feature = feature;
        public bool IsMatch(T creatureFeature) => _feature.Equals(creatureFeature);
    }
    class FeatureMany<T> : IFeature<T> where T : IEquatable<T>
    {
        private ISet<T> _features;
        public FeatureMany(params T[] features) => _features = new HashSet<T>(features);
	
	    public bool IsMatch(T creatureFeature) => _features.Contains(creatureFeature);
    }
    class FeatureFactory
    {
        public IFeature<T> MakeFeature<T>(params T[] features) where T : IEquatable<T>
	    {
            if(!features.Any())
		    {
                return new FeatureAny<T>();
		    }
            else if(features.Length == 1)
		    {
                return new FeatureSingle<T>(features.Single());
		    }
            else
		    {
                return new FeatureMany<T>(features);
		    }
	    }
    }
    enum SkinColor
    {
        White,
        Black,
        Green
    }
    interface ICreature
    {
        string Name { get; set; }
        int NumberOfLegs { get; set; }
        SkinColor SkinColor { get; set; }
        ISpecies Species { get; set; }
    }
    interface ISpecies
    {
        IFeature<string> Name { get; set; }
        IFeature<int> NumberOfLegs { get; set; }
        IFeature<SkinColor> SkinColor { get; set; }
    }
