    class Foo
	{
		public Guid value1;
		public decimal value2;
		public SomeCustomEnum value3;
	}
	[Serializable]
	class Bar : Foo, ISerializable
	{
		private int a;
		public Bar()
		{
		}
		#region Implementation of ISerializable
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("a", a);
			info.AddValue("value1", value1);
			info.AddValue("value2", value2);
		}
		protected Bar(SerializationInfo info,StreamingContext context)
		{
			a = info.GetInt32("a");
			value1 = (Guid)info.GetValue("value1", typeof(Guid));
			value2 = info.GetDecimal("value2");
		}
		#endregion
	}
