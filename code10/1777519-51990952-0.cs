    interface IFetchStrategy<TEntity, TProperty> where TEntity : class
    {
        Expression<Func<TEntity, TProperty>> Apply();
    }
    class ModelFetchStrategy : IFetchStrategy<UserCar, Model>
    {
        public Expression<Func<UserCar, Model>> Apply()
        {
            return x => x.Model;
        }
    }
    class Model { }
    class UserCar
    {
        public Model Model { get; set; }
    }
