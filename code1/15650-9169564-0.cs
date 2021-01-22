	public class DisposableComponentWrapper : IComponent
	{
		private IDisposable disposable;
		public DisposableComponentWrapper(IDisposable disposable)
		{
			this.disposable = disposable;
		}
		public DisposableComponentWrapper(IDisposable disposable, ISite site)
			: this(disposable)
		{
			Site = site;
		}
		public void Dispose()
		{
			if (disposable != null)
			{
				disposable.Dispose();
			}
			if (Disposed != null)
			{
				Disposed(this, EventArgs.Empty);
			}
		}
		public ISite Site { get; set; }
		public event EventHandler Disposed;
	}
