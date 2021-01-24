    public class PhoneItem : IItem
	{
		public PhoneItem(string text)
		{
			// some code
		}
	}
	public interface IRecognizer
	{
		IItem Recognize(int index, string text);
	}
	public class PhoneRecognizer : IRecognizer
	{
		public IItem Recognize(int index, string text)
		{
			return index == 0 ? new PhoneItem(text) : null;
		}
	}
	public class ItemFactory
	{
		private IEnumerable<IRecognizer> _recognizers = new [] 
		{
			new PhoneRecognizer(),
			new FullNameRecognizer()
		};
		
		public IItem CreateItem(int index, string text)
		{
			foreach (var rec in _recognizers)
			{
				var item = rec.Recognize(index, text);
				if (item != null)
				{
					return item;
				}
			}
			throw new Exception("Item not recognized");
		}
	}
