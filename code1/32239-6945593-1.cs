    public interface IHasDescription : IEntity
    {
        /// <summary>
        /// Creates a description (in english) of the Entity.
        /// </summary>
        string EntityDescription { get; }
    }
