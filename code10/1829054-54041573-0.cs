	foreach (S3Object obj in response.S3Objects)
	{
		try
		{
			string filename = directoryPath + "\\" + obj.Key;
			FileStream fs = File.Create(filename);
			fs.Close();
			Console.WriteLine("{0}", obj.Key);
			fileTransferUtility.Download(filename, bucketName, obj.Key);
		}
		 catch (Exception Excep)
		 {
			 Console.WriteLine(Excep.Message, Excep.InnerException);
		}
	}
