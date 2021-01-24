	public class Error
	{
		public string Message { get; private set; }
		public int ErrorNumber { get; private set; } 
        public Error(object vendorError) 
		{
			var t = vendorError.GetType();
			foreach (var source in t.GetProperties(BindingFlags.Instance | BindingFlags.Public))
			{
				foreach (var dest in typeof(Error).GetProperties(BindingFlags.Instance | BindingFlags.Public))
				{
					if (dest.Name != source.Name) continue;
					if (dest.PropertyType != source.PropertyType) continue;
					dest.SetValue(this, source.GetValue(vendorError, null));
				}
			}
		}
	}
