    public class LimitedSizeObservableCollection<T> : ObservableCollection<T>
    {
        public int Capacity { get; set; } = 0;
        protected override void InsertItem(int index, T item)
        {
            if (this.Capacity > 0 && this.Count >= this.Capacity)
            {
                throw new Exception(string.Format("The maximum number of items in the list  ({0}) has been reached, unable to add further items", this.Capacity));
            }
            else
            {
                base.InsertItem(index, item);
            }
        }
    }
