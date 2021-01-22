	class Program
	{
		static void Main(string[] args)
		{
			var wrapper = new VersionRetrieverWrapper();
			wrapper.Request = new InheritedRequestA();
			wrapper.Request.Member = "Request";
			wrapper.Response = new InheritedResponseA();
			wrapper.Response.Member = "Response";
			Console.WriteLine(Save(wrapper));
		}
		public static string Save(Wrapper wrapper)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Wrapper));
			string serializedObject = string.Empty;
			using (MemoryStream stream = new MemoryStream())
			{
				serializer.Serialize(stream, wrapper);
				stream.Position = 0;
				using (StreamReader reader = new StreamReader(stream))
				{
					serializedObject = reader.ReadToEnd();
				}
			}
			return serializedObject;
		}
	}
	public partial class InheritedRequestA : BaseRequest
	{
	}
	public partial class InheritedResponseA : BaseRequest
	{
	}
	public partial class BaseRequest
	{
		//members here
		public string Member;
	}
	[XmlInclude(typeof(VersionRetrieverWrapper))]
	public class Wrapper
	{
	}
	public class VersionRetrieverWrapper : Wrapper
	{
		public InheritedRequestA Request { get; set; }
		public InheritedResponseA Response { get; set; }
	}
