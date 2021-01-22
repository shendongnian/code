	namespace Data
	{
		class DALDataObject : DataObject, IDataObject
		{
			public DALDataObject(int id, string name)
			{
				this.id = id;
				this.name = name;
			}
		}
		public class Connector
		{
			public static IDataObject LoadDataObject(int objectId)
			{
				return new DALDataObject(objectId, string.Format("Dummy object {0}", objectId));
			}
			public static IEnumerable<IDataObject> LoadDataObjects(int startRange, int endRange)
			{
				var list = new List<IDataObject>();
				for (var i = startRange; i < endRange; i++)
					list.Add(new DALDataObject(i, string.Format("Dummy object {0}", i)));
				return list;
			}
		}
	}
