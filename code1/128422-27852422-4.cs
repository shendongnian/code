    public abstract class Command2<T1, T2> : ICommand {
		public abstract T2 Execute2(T1 parameter);
	}
	public class DelegateCommand2<T1, T2> : Command2<T1, T2> {
		public DelegateCommand2(Func<T1, T2> execute, Predicate<T1> canExecute) {
			_execute = execute;
			_canExecute = canExecute;
		}
		public override T2 Execute2(T1 parameter) {
			if (CanExecute(parameter) == false)
                return default(T2);
			else
				return _execute((T1)parameter);
		}
	}
        
