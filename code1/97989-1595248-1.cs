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
			public static IDummyObject LoadDummyObject(int objectId)
			{
				return new DummyDataObject(objectId, string.Format("Dummy object {0}", objectId));
			}
			public static IEnumerable<IDummyObject> LoadDummyObjects(int startRange, int endRange)
			{
				var list = new List<IDummyObject>();
				for (var i = startRange; i < endRange; i++)
					list.Add(new DummyDataObject(i, string.Format("Dummy object {0}", i)));
				return list;
			}
		}
	}
