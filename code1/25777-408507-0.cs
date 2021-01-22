    class C : IDisposable
    {
    	public IDisposable IDisposable { get { return this; } }
    	void IDisposable.Dispose() { }
    }
