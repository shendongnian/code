	public class ViewModel : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged = ( s, e ) => {
		}; // the lambda ensures PropertyChanged is never null
		public DateFormatChoices Choices {
			get;
			private set;
		}
		DateFormatChoice _chosen;
		public DateFormatChoice Chosen {
			get {
				return _chosen;
			}
			set {
				_chosen = value;
				Notify( PropertyChanged, () => Chosen );
			}
		}
		public DateTime CurrentDateTime {
			get {
				return DateTime.Now;
			}
		}
		public ViewModel() {
			Choices = new DateFormatChoices();
		}
		// expression used to avoid string literals
		private void Notify<T>( PropertyChangedEventHandler handler, Expression<Func<T>> expression ) {
			var memberexpression = expression.Body as MemberExpression;
			handler( this, new PropertyChangedEventArgs( memberexpression.Member.Name ) );
		}
	}
