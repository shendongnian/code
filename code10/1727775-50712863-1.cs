    public class Solution1<T> : ObservableCollection<T>
    {
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                DoSomething();
            base.OnCollectionChanged(e);
        }
        ...
    }
