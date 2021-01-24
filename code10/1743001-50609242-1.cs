    ... 
    using System.IO;
    using Xamarin.Forms;
    using BSoft.iOS;
    [assembly: Dependency(typeof(SaveReadFiles_iOS))] /// !! Important
    namespace BSoft.iOS
    {
     public class SaveReadFiles_iOS : ISaveAndLoad
     {
        public SaveReadFiles_iOS(){}
        public void SaveFile(string filename, string text)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            File.WriteAllText(filePath, text);
        }
        public bool CheckExistingFile(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return File.Exists(filePath);
        }
        public string ReadFile(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            if(File.Exists(filePath))
                return File.ReadAllText(filePath);
            return "";
        }
       }
      }
