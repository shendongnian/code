	public class DownloadRuleCollection : List<DownloadRule> {
		public string SomeProperty { get; set; }
		public void Serialize(string fileName) {
			Serializer.Serialize(
				new DownloadRuleCollection_SerializationWrapper {
					Collection = this,
					SomeProperty = SomeProperty
				}, fileName);
		}
		public static DownloadRuleCollection Deserialize(string fileName) {
			var wrapper = Serializer.Deserialize<DownloadRuleCollection_SerializationWrapper>(fileName);
			var result = wrapper.Collection;
			result.SomeProperty = wrapper.SomeProperty;
			return result;
		}
		[DataContract(Name = "DownloadRuleCollection")]
		private class DownloadRuleCollection_SerializationWrapper {
			[DataMember(EmitDefaultValue = false, Name = "SomeProperty", Order = 0)]
			public string SomeProperty { get; set; }
			[DataMember(EmitDefaultValue = false, Name = "DownloadRules", Order = 1)]
			public DownloadRuleCollection Collection;
		}
	}
	
	[DataContract]
	public class DownloadRule {
		[DataMember(EmitDefaultValue = false)]
		public string Name { get; set; }
	}
    public static class Serializer {
		public static void Serialize<T>(T obj, string fileName) {
			using(XmlWriter writer = XmlWriter.Create(fileName, new XmlWriterSettings { Indent = true }))
				new DataContractSerializer(typeof(T)).WriteObject(writer, obj);
		}
		public static T Deserialize<T>(Stream stream) {
			return (T)new DataContractSerializer(typeof(T)).ReadObject(stream);
		}
		public static T Deserialize<T>(string fileName) {
			using(FileStream fs = File.OpenRead(fileName)) {
				return Deserialize<T>(fs);
			}
		}
	}
