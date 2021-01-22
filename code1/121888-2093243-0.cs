    string path = @"Your Path";
			string[] projects = Directory.GetFiles(path, "*.csproj", SearchOption.AllDirectories);
			List<string> badRefferences = new List<string>();
			foreach (string project in projects)
			{
				XmlDocument projectXml = new XmlDocument();
				projectXml.Load(project);
				XmlNodeList hintPathes = projectXml.GetElementsByTagName("HintPath");
				foreach (XmlNode hintPath in hintPathes)
				{
					FileInfo projectFI = new FileInfo(project);
					string reference = Path.GetFullPath(Path.Combine(projectFI.DirectoryName, hintPath.InnerText));
					if (!File.Exists(reference))
					{
						badRefferences.Add(reference);
					}
				}
			}
