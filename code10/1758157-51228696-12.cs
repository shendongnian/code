	public interface IValidationRule<T> where T : INotifyPropertyChanged
	{
		bool Check(T value);
	}
	public class ValidatableObject<TValue> where TValue : INotifyPropertyChanged
	{
		public IObservable<bool> IsValid { get; private set; }
		public TValue Value { get; }
		
		public IEnumerable<IValidationRule<TValue>> Rules { get; }
		private ObservableCollection<IValidationRule<TValue>> _rules;
		
		public IDisposable AddRule(IValidationRule<TValue> rule)
		{
			_rules.Add(rule);
			return Disposable.Create(() => _rules.Remove(rule));
		}
		
		public ValidatableObject(TValue value)
		{
			Value = value;
			
			_rules = new ObservableCollection<IValidationRule<TValue>>();
	
			var rulesChanged = 
				Observable
					.FromEventPattern<
							NotifyCollectionChangedEventHandler,
							NotifyCollectionChangedEventArgs>(
						h => _rules.CollectionChanged += h,
						h => _rules.CollectionChanged -= h)
					.Select(ep => Unit.Default);
						
			var valueChanged =
				Observable
					.FromEventPattern<
							PropertyChangedEventHandler,
							PropertyChangedEventArgs>(
						h => value.PropertyChanged += h,
						h => value.PropertyChanged -= h)
					.Select(ep => Unit.Default);
			
			this.IsValid =
				Observable
					.Merge(rulesChanged, valueChanged)
					.Select(ep => _rules.All(rule => rule.Check(Value)))
					.ObserveOn(Scheduler.Default);
		}
	}
