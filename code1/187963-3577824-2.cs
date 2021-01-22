    /// <summary>
    /// Represents a value whose changes can be observed.
    /// </summary>
    /// <typeparam name="T">The type of value.</typeparam>
    public class Observable<T> : IObservable<T>, INotifyPropertyChanged
    {
        private T value;
        private readonly List<AnonymousObserver> observers = new List<AnonymousObserver>(2);
        private PropertyChangedEventHandler propertyChanged;
    
        /// <summary>
        /// Constructs a new observable with a default value.
        /// </summary>
        public Observable()
        {
        }
    
        public Observable(T initalValue)
        {
            this.value = initialValue;
        }
    
        /// <summary>
        /// Gets the underlying value of the observable.
        /// </summary>
        public T Value
        {
            get { return this.value; }
            set
            {
                var valueHasChanged = !EqualityComparer<T>.Default.Equals(this.value, value);
                this.value = value;
    
                // Notify the observers of the value.
                this.observers
                    .Select(o => o.Observer)
                    .Where(o => o != null)
                    .Do(o => o.OnNext(value))
                    .Run();
    
                // For INotifyPropertyChange support, useful in WPF and Silverlight.
                if (valueHasChanged && propertyChanged != null)
                {
                   propertyChanged(this, new PropertyChangedEventArgs("Value"));
                }
            }
        }
    
        /// <summary>
        /// Converts the observable to a string. If the value isn't null, this will return
        /// the value string.
        /// </summary>
        /// <returns>The value .ToString'd, or the default string value of the observable class.</returns>
        public override string ToString()
        {
            return value != null ? value.ToString() : "Observable<" + typeof(T).Name + "> with null value.";
        }
    
        /// <summary>
        /// Implicitly converts an Observable to its underlying value.
        /// </summary>
        /// <param name="input">The observable.</param>
        /// <returns>The observable's value.</returns>
        public static implicit operator T(Observable<T> input)
        {
            return input.Value;
        }
    
        /// <summary>
        /// Subscribes to changes in the observable.
        /// </summary>
        /// <param name="observer">The subscriber.</param>
        /// <returns>A disposable object. When disposed, the observer will stop receiving events.</returns>
        public IDisposable Subscribe(IObserver<T> observer)
        {
            var disposableObserver = new AnonymousObserver(observer);
            this.observers.Add(disposableObserver);
            return disposableObserver;
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add { this.propertyChanged += value; }
            remove { this.propertyChanged -= value; }
        }
    
        class AnonymousObserver : IDisposable
        {
            public IObserver<T> Observer { get; private set; }
    
            public AnonymousObserver(IObserver<T> observer)
            {
                this.Observer = observer;
            }
    
            public void Dispose()
            {
                this.Observer = null;
            }
        }
    }
