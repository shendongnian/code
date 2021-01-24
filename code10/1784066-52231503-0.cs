	using (var stream = File.OpenRead(filenameAndExtension))
	{
		using (var peFile = new PEReader(stream))
		{
			var headers = peFile.PEHeaders;
			Console.WriteLine($"Reading {filenameAndExtension} with System.Reflection.Metadata");
			Console.WriteLine($"  IsDll: {headers.IsDll}");
			Console.WriteLine($"  IsExe: {headers.IsExe}");
			Console.WriteLine($"  IsConsoleApplication: {headers.IsConsoleApplication}");
			PEFileKinds reverseEngineeredKind;
			// NOTE: the header values cause IsConsoleApplication to return
			//       true for DLLs, so we need to check IsDll first
			if (headers.IsDll)
			{
				reverseEngineeredKind = PEFileKinds.Dll;
			}
			else if (headers.IsConsoleApplication)
			{
				reverseEngineeredKind = PEFileKinds.ConsoleApplication;
			}
			else
			{
				reverseEngineeredKind = PEFileKinds.WindowApplication;
			}
			Console.WriteLine($"  Reverse-engineered kind: {reverseEngineeredKind}");
		}
	}
