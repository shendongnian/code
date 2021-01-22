	public class ComboBoxItem<T>
	{
		/// The text to display.
		private string text = "";
		/// The associated tag.
		private T tag = default(T);
		public string Text
		{
			get
			{
				return text;
			}
		}
		public T Tag
		{
			get
			{
				return tag;
			}
		}
		public override string ToString()
		{
			return text;
		}
	
		// Add various constructors here to fit your needs
	}
