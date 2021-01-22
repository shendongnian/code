	using System.IO;
	using System.Xml.Serialization;
	namespace TestSerialization
	{
		class Program
		{
			static void Main(string[] args)
			{
				string content= @"<DataSet>
		<User>
			<UserName>Test</UserName>
			<Email>test@test.com</Email>
			<Details>
				<Detail>
					<ID>1</ID>
					<Name>TestDetails</Name>
					<Value>1</Value>
				</Detail>
				<Detail>
					<ID>2</ID>
					<Name>Testing</Name>
					<Value>3</Value>
				</Detail>
			</Details>
		</User>
	</DataSet>";
				XmlSerializer serializaer = new XmlSerializer(typeof(DataSet));
				DataSet o = (DataSet) serializaer.Deserialize(new StringReader(content));
			}
		}
		public class User
		{
			public string UserName { get; set; }
			public string Email { get; set; }
			public Detail[] Details { get; set; }
		}
		
		public class Detail
		{
			public int ID { get; set; }
			public string Name { get; set; }
			public string Value { get; set; }
		}
		public class DataSet
		{
			public User User;
		}
	}
