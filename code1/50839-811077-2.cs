    public class ObservableStack<T> : ObservableCollection<T> 
    {
        private T collapsed;
        public event EventHandler BeforePop;
        public T Peek() {
            if (collapsed != null) {
                Remove(collapsed);
                collapsed = default(T);
            }
            return this.FirstOrDefault();
        }
        public T Pop() {
            if (collapsed != null) { Remove(collapsed); }
            T result = (collapsed = this.FirstOrDefault());
            if (BeforePop != null && result != null) BeforePop(this, new EventArgs());
            return result;
        }
        public void Push(T item) {
            if (collapsed != null) {
                Remove(collapsed);
                collapsed = default(T);
            }
            Insert(0, item);
        }
    }
