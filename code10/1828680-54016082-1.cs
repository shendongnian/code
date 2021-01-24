    var proj = System.Xml.XmlReader.Create(args[1]);
    var msbuild = new Microsoft.Build.Evaluation.Project(proj);
    var logger = new ExtendLogger();
    bool result = msbuild.Build(logger);
    string logString = logger.GetLog();
    Console.WriteLine("Build success?: " + result.ToString());
    Console.WriteLine(logString );
    Console.ReadKey();
