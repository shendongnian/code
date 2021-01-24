    public class TypeAdapter
    {
        public PagedCollectionResult<T> Adapt<S,T>(PagedCollectionResultDTO<S> source) 
           where T: IExampleModel<S>, new()
        {
            var target = new PagedCollectionResult<T>();
            target.Page = source.Page;
            target.Page = source.PageSize;
            target.Total = source.Total;
            target.Data = AdaptList<S,T>(source.Data).ToList();
            return target;
        }
        protected IEnumerable<T> AdaptList<S,T>(IEnumerable<S> sourceList) 
           where T : IExampleModel<S>, new()
        {
            foreach (S sourceItem in sourceList)
            {
                T targetItem = new T();
                targetItem.Adapt(sourceItem);
                yield return targetItem;
            }
        }
    }
