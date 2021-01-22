    /// <summary>
    /// Abstract Base class which implements IDataRepository interface.
    /// </summary>
    /// <typeparam name="T">A POCO entity</typeparam>
    public abstract class DataRepository<T> : IDataRepository<T>
        where T : class, IIdEntity
    {
