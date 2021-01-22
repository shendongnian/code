    public class Observable<T> : IObservable<T>, INotifyPropertyChanged 
    { 
        private readonly BehaviorSubject<T> values; 
    
        private PropertyChangedEventHandler propertyChanged; 
    
        public Observable() : this(default(T))
        {
        } 
     
        public Observable(T initalValue) 
        { 
            this.values = new BehaviorSubject<T>(initalValue);
            values.DistinctUntilChanged().Subscribe(FirePropertyChanged);
        }
     
        public T Value 
        { 
            get { return this.values.First(); } 
            set { values.OnNext(value); } 
        }
    
        private void FirePropertyChanged(T value)
        {
            var handler = this.propertyChanged;
    
            if (handler != null)
                handler(this, new PropertyChangedEventArgs("Value"));
        }
    
        public override string ToString() 
        { 
            return value != null ? value.ToString() : "Observable<" + typeof(T).Name + "> with null value."; 
        } 
     
        public static implicit operator T(Observable<T> input) 
        { 
            return input.Value; 
        } 
     
        public IDisposable Subscribe(IObserver<T> observer) 
        { 
            return values.Subscribe(observer);
        } 
     
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged 
        { 
            add { this.propertyChanged += value; } 
            remove { this.propertyChanged -= value; } 
        } 
    }
 
