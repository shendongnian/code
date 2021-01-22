	namespace Model
	{
		public interface IDataObject
		{
			int id { get; }
			string name { get; set; }
		}
		public abstract class DataObjectBase
		{
			public abstract int id { get; protected set; }
			public abstract string name { get; set; }
		}
		public class DataObject : DataObjectBase, IDataObject
		{
			public override int id { get; protected set; }
			public override string name { get; set; }
		}	
	}
