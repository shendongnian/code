	public class JsonHelper
	{
		public static string Serialize(Object data)
		{
			return Serialize(data,Encoding.UTF8);
		}
		public static string Serialize(Object data, Encoding encoding)
		{
			System.Runtime.Serialization.Json.DataContractJsonSerializer serializer  = new System.Runtime.Serialization.Json.DataContractJsonSerializer(data.GetType());
			using(System.IO.MemoryStream ms = new System.IO.MemoryStream())
			{
				serializer.WriteObject(ms, data);
				return encoding.GetString(ms.ToArray());
			}
		}
		public static Object Deserialize(Type t, string sJsonText)
		{
			return Deserialize(t,sJsonText , Encoding.UTF8);
		}
		public static Object Deserialize(Type t, string sJsonText,Encoding encoding)
		{
				byte[] byteArray = encoding.GetBytes(sJsonText);
				using (System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArray))
				{
					System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(t);
					return serializer.ReadObject(ms);
				}
		}
	}
