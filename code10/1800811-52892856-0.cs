    [Serializable]
    public class FileNameInfo
    {
        public string[] fileNames;
        public FileNameInfo(string[] fileNames)
        {
            this.fileNames = fileNames;
        }
    }
    
    class PreBuildFileNamesSaver : IPreprocessBuildWithReport
    {
        public int callbackOrder { get { return 0; } }
        public void OnPreprocessBuild(UnityEditor.Build.Reporting.BuildReport report)
        {
            //The Resources folder path
            string resourcsPath = Application.dataPath + "/Resources";
    
            //Get file names except the ".meta" extension
            string[] fileNames = Directory.GetFiles(resourcsPath)
                .Where(x => Path.GetExtension(x) != ".meta").ToArray();
    
            //Convert the Names to Json to make it easier to access when reading it
            FileNameInfo fileInfo = new FileNameInfo(fileNames);
            string fileInfoJson = JsonUtility.ToJson(fileInfo);
    
            //Save the json to the Resources folder as "FileNames.txt"
            File.WriteAllText(Application.dataPath + "/Resources/FileNames.txt", fileInfoJson);
    
            AssetDatabase.Refresh();
        }
    }
