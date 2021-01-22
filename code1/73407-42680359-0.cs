            public static string ReadAssemblyResourceFile(string resourcefilename)
    		{
    using (var stream = Assembly.Load("GM.B2U.DAL").GetManifestResourceStream("GM.B2U.DAL.Resources."
        + resourcefilename)) 			{
        				if (stream == null) throw new MyExceptionDoNotLog($"GM.B2U.DAL.Resources.{resourcefilename} not found in the Assembly GM.B2U.DAL.dll !");
        				using (var reader = new StreamReader(stream))
        				{
        					return reader.ReadToEnd();
        				} 			
                    }
    		}
