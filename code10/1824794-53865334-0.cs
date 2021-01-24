	public class State<T>
	{
		public State() { }
		public State(T t) { this.t = t; }
	
		private T t = default(T);
		private readonly object theLock = new object();
	
		public void With(Action<T> action)
		{
			lock (this.theLock)
			{
				action(this.t);
			}
		}
	
		public void Update(Func<T, T> action)
		{
			lock (this.theLock)
			{
				this.t = action(this.t);
			}
		}
	
		public R Select<R>(Func<T, R> action)
		{
			lock (this.theLock)
			{
				return action(this.t);
			}
		}
		
		public Task<R> SelectAsync<R>(Func<T, Task<R>> action)
		{
			lock (this.theLock)
			{
				return action(this.t);
			}
		}	
	}
