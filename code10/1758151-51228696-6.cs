	public class ValidatableObject<TValue>
	{
		public bool IsValid { get; private set; } = true;
		public TValue Value { get; }
		public System.Collections.ObjectModel.ObservableCollection<IValidationRule<TValue>> Rules { get; }
	
		public ValidatableObject(TValue value)
		{
			Value = value;
			Rules = new ObservableCollection<IValidationRule<TValue>>();
	
			Observable
				.FromEventPattern<
						System.Collections.Specialized.NotifyCollectionChangedEventHandler,
						System.Collections.Specialized.NotifyCollectionChangedEventArgs>(
					h => Rules.CollectionChanged += h,
					h => Rules.CollectionChanged -= h)
				.Select(ep => Rules.All(rule => rule.Check(Value)))
				.Subscribe(b => IsValid = b);
		}
	}
