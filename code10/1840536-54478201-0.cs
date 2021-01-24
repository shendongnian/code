	public class ClassA : IMyIterface
	{
		public event EventHandler<int> OnChanged;
		public void SomethingChanged()
		{
			this.OnChanged?.Invoke(this, 42);
		}
	}
    // .. same for ClassB...
