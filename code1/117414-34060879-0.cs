    	public class Locker : IDisposable
	{
		bool _isActive;
		public bool IsActive
		{
			get { return _isActive; }
		}
		private Locker()
		{
			_isActive = false;
		}
		public static Locker Create()
		{
			return new Locker();
		}
		public void Dispose()
		{
			_isActive = false;
		}
		public Locker Activate()
		{
			_isActive = true;
			return this;
		}
	}
