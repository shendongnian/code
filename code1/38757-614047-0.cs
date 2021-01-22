	public class MyClass
	{
		private AutoUpdatingObject dataObject;
		public AutoUpdatingObject DataObject
		{
			get { return dataObject; }
			set { dataObject = value; DataObjectChanged(this, new EventArgs()); }
		}
		public event EventHandler DataObjectChanged = delegate { };
	}
