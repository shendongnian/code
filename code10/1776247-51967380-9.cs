    public abstract class AnimalFactory
    {
    	public abstract string SpeciesName { get; }
    	public abstract Type TypeCreated { get; }
    	public abstract Animal Create(AnimalParams args);
    	public abstract string Serialize(Animal animal);
    }
