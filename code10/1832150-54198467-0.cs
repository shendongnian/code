        PBXProject project = new PBXProject();
        string sPath = PBXProject.GetPBXProjectPath(pathToBuiltProject);
        project.ReadFromFile(sPath);
        string tn = PBXProject.GetUnityTargetName();
        string g = project.TargetGuidByName(tn);
        project.AddFileToBuild(g, project.AddFile("Data/Raw/<YourFile.png>", "<YourPathInXcodeProject>/<YourFile.png>"));
        File.WriteAllText(sPath, project.WriteToString());
