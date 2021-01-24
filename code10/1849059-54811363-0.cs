    public abstract class Model
    { 
        // HACK: Don't bother wiring up OnPropertyChanged here, since we don't expect ID to get updated that often, but need a public setter for the Provider
        Guid ID { get; set; }
    }
    // HACK: While using a generic here makes for readable code, it may become problematic if you want to inherit your models
    public class ModelProvider<TModelType> where TModelType : Model, new()
    {
        // HACK: Use better dependency injection than this
        private static ModelProvider<TModelType> _instance = new ModelProvider<TModelType>();
        public static ModelProvider<TModelType> Instance => _instance;
        private ModelProvider() { }
        // TODO: Make this into a dictionary of WeakReferences so that you're not holding stale data in memory
        ConcurrentDictionary<Guid, TModelType> LoadedModels = new Dictionary<Guid, TModelType>();
        private TModelType GenerateModel(Guid id) => new TModelType { ID = id };
        private TModelType LoadKnownModel(Guid id)
        {
            throw new NotImplementedException("Implement a data store to get known models");
        }
        public TModelType GetNew() => LoadedModels.AddOrUpdate(Guid.NewGuid(). GenerateModel);
        public TModelType GetById(Guid id) => LoadedModels.GetOrAdd(id, LoadKnownModel);
    }
