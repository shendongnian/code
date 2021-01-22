        [Serializable]
		public class OType
		{
			public int SomeIdentifier { get; set; }
			public string SomeData { get; set; }
			public override string ToString()
			{
				return string.Format("{0}: {1}", SomeIdentifier, SomeData);
			}
		}
		[Serializable]
		public class MyClass : ISerializable
		{
			public List<OType> Value;
			public MyClass() {	}
			public MyClass(SerializationInfo info, StreamingContext context)
			{
				this.Value = (List<OType>)info.GetValue("value", typeof(List<OType>));
			}
			void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			{
				info.AddValue("value", Value, typeof(List<OType>));
			}
		}
    ...
            var x = new MyClass();
			x.Value = new OType[] { new OType { SomeIdentifier = 1, SomeData = "Hello" }, new OType { SomeIdentifier = 2, SomeData = "World" } }.ToList();
			var xSerialized = serialize(x);
			Console.WriteLine("Serialized object is {0}bytes", xSerialized.Length);
			var xDeserialized = deserialize<MyClass>(xSerialized);
			Console.WriteLine("{0} {1}", xDeserialized.Value[0], xDeserialized.Value[1]);
