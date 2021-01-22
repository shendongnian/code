     static string DataContractSerializeUsingByteArray<T>(T obj)
		{
			string sRet = "";
			DataContractSerializer serializer = new DataContractSerializer(typeof(T)); 
			using (MemoryStream memStream = new MemoryStream()) 
			{
				serializer.WriteObject(memStream, obj); 
				byte[] blob = memStream.ToArray(); 
				var encoding= new System.Text.UTF7Encoding();
				sRet = encoding.GetString(blob);
			}
			return sRet;
		} 
