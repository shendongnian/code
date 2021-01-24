	public class ValidatableObject<TValue>
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
	
			this.IsValid =
				Observable
					.FromEventPattern<
							NotifyCollectionChangedEventHandler,
							NotifyCollectionChangedEventArgs>(
						h => _rules.CollectionChanged += h,
						h => _rules.CollectionChanged -= h)
					.Select(ep => _rules.All(rule => rule.Check(Value)))
					.ObserveOn(Scheduler.Default);
		}
	}
