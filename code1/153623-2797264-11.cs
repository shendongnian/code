    namespace ModelProject
    {
        /// <summary>
        /// Interface implemented by a Repository to return
        /// <see cref="IQueryable`T"/> collections of objects
        /// </summary>
        /// <typeparam name="T">Object type to return</typeparam>
        public interface IRepository<T>
        {
            IQueryable<T> Items { get; }
        }
    }
