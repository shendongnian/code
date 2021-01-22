        public interface IRepository<TModel>
        {
            List<TModel> Get<TModel>(Func<TModel, bool> predicate);
        }
        public interface IErpManager
        {
            List<TResult> Load<TKey, TResult>(ILoad erpObj, List<TKey> list, Func<TKey, TResult> select);
            List<TModel> Get<TModel>(IRepository<TModel> erpObj, Func<TModel, bool> predicate);
        }
