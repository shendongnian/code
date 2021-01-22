    public class ObservableSetCollection<T> : ObservableCollection<T> {
        public void Append(T item) {
            if (Contains(item)) return;
            base.Add(item);
        }
    }
