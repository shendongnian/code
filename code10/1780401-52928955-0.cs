    // custom IGrouping implementation which is required by ListView
    public class Grouping<TKey, TElement> : ObservableCollectionExtended<TElement>, IGrouping<TKey, TElement>
    {
        public Grouping(IGroup<TElement, TKey> group) 
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            Key = group.GroupKey;
            group.List.Connect().Bind(this).Subscribe();
        }
        public TKey Key { get; private set; }
    }
    // this.Ints is an ObservableCollection<int> which I manipulate thru UI
    this.Ints
        .ToObservableChangeSet()
        .GroupOn(i => (int)(i / 10)) // group by 10s
        .Transform(group => new Grouping<int, int>(group)) // transform DynamicData IGroup into our IGrouping implementation
        .Sort(SortExpressionComparer<Grouping<int, int>>.Ascending(t => t.Key)) // sort by keys
        .ObserveOnDispatcher()
        .Bind(this.FilteredInts) // this.FilterdInts is used as binding source for CollectionViewSource in UI
        .Subscribe();
