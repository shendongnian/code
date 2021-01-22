    public interface IDataRepository { }
    internal class DataRepository : SimpleRepository, IDataRepository
    {
    }
    ObjectFactory.Initialize(
        x => x.ForRequestedType<IDataRepository>()  
            .TheDefaultIsConcreteType<DataRepository>()  
            .CacheBy(InstanceScope.Hybrid));
