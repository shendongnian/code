    var censusSorter = new Sorter<CensusEntryVM>();
    censusSorter.AddSortExpression("SubscriberId", e=>e.SubscriberId);
    censusSorter.AddSortExpression("LastName", e => e.SubscriberId);
    View.CensusEntryDataSource = censusSorter.Sort(q.AsQueryable(), 
        new Tuple<string, SorterSortDirection>("SubscriberId", SorterSortDirection.Descending),
        new Tuple<string, SorterSortDirection>("LastName", SorterSortDirection.Ascending))
        .ToList();
    internal class Sorter<E>
    {
        public Sorter()
        {
        }
        public void AddSortExpression<P>(string name, Expression<Func<E, P>> selector)
        {
            // Register all possible types of sorting for each parameter
            firstPasses.Add(name, s => s.OrderBy(selector));
            nextPasses.Add(name, s => s.ThenBy(selector));
            firstPassesDesc.Add(name, s => s.OrderByDescending(selector));
            nextPassesDesc.Add(name, s => s.OrderByDescending(selector));
        } 
        public IOrderedQueryable<E> Sort(IQueryable<E> list, 
                                         params Tuple<string, SorterSortDirection>[] names) 
        { 
            IOrderedQueryable<E> result = null; 
            foreach (var entry in names)
            {
                result = result == null 
                       ? SortFirst(entry.Item1, entry.Item2, list) 
                       : SortNext(entry.Item1, entry.Item2, result); 
            } 
            return result; 
        } 
        private IOrderedQueryable<E> SortFirst(string name, SorterSortDirection direction, 
                                               IQueryable<E> source) 
        { 
            return direction == SorterSortDirection.Descending
                 ? firstPassesDesc[name].Invoke(source) 
                 : firstPasses[name].Invoke(source);
        } 
        private IOrderedQueryable<E> SortNext(string name, SorterSortDirection direction, 
                                              IOrderedQueryable<E> source) 
        {
            return direction == SorterSortDirection.Descending
                 ? nextPassesDesc[name].Invoke(source) 
                 : nextPasses[name].Invoke(source); 
        }
        private readonly FirstPasses firstPasses = new FirstPasses(); 
        private readonly NextPasses nextPasses = new NextPasses();
        private readonly FirstPasses firstPassesDesc = new FirstPasses();
        private readonly NextPasses nextPassesDesc = new NextPasses();
        private class FirstPasses : Dictionary<string, Func<IQueryable<E>, IOrderedQueryable<E>>> { }
        private class NextPasses : Dictionary<string, Func<IOrderedQueryable<E>, IOrderedQueryable<E>>> { }
    }
