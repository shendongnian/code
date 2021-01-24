    namespace MyApp.Services
    {
        public interface IFileService
        {
            void CreateDirectoryStructure(string path = "");
            void CreateFolder(string name, string path = "");
            void CreateFile(string name, string path = "");
            bool CheckFileExists(string path);
            bool CheckFolderExists(string path); 
        }
    }
