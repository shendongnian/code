    static void Main(string[] args)
         {
            if(args.Count() != 2)
            {
                Usage();
                return;
            }
            var rootDir = args[0];
            var output = args[1];
            var files = Directory.EnumerateFiles(rootDir, 
                                                 "*.*proj", 
                                                 SearchOption.AllDirectories);
            var configs = new StringBuilder();
            var configDefs = new string[]{
            ".Debug|Any CPU.ActiveCfg = Debug|Any CPU",
            ".Release|Any CPU.ActiveCfg = Release|Any CPU",
            "Other_configurations_see_solution_for_how"
            };
            using(var sw = new StreamWriter(output))
            {
                sw.WriteLine(Resources.Head);
                foreach(var file in files)
                {
                    var relpath = file.Substring(rootDir.Length + 1);
                    var split= relpath.Split('\\');
                    var name = split[0];
                    var path = relpath;
                    sw.WriteLine("Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"{0}\", \"{1}\", \"{0}\"", name, path);
                    sw.WriteLine("EndProject");
                    foreach(var configDef in configDefs)
                    {
                        configs.AppendLine(string.Format("{0}{1}", file, configDef));
                    }
                }
                sw.WriteLine(@"Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU		
		Release|Any CPU = Release|Any CPU
		...Other_configurations_see_solution_for_how...
	EndGlobalSection 
        GlobalSection(ProjectConfigurationPlatforms) = postSolution");
                sw.WriteLine(configs.ToString());
                sw.WriteLine(Resources.Tail);
            }
        }
