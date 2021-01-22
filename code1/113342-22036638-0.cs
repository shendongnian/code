    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    
    namespace DevExpressFileEditing
    {
        class Program
        {
            static List<FileInfo> _files;
            private static Dictionary<string, string> _replaceList;
    
            static void Main()
            {
                _files = new List<FileInfo>();
                _replaceList = new Dictionary<string, string>();
                
                Console.WriteLine("Dark directory searching");
                SearchFilesInDirectories(new DirectoryInfo(@"C:\Sourcebank\Dark"));
                
                Console.WriteLine("Light directory searching");
                SearchFilesInDirectories(new DirectoryInfo(@"C:\Sourcebank\Light"));
                
                Console.WriteLine("{0} files found", _files.Count.ToString(CultureInfo.InvariantCulture));
    
                Console.WriteLine("Replace dictinary creating");
                CreateReplaceList();
                Console.WriteLine("{0} item added", _replaceList.Count.ToString(CultureInfo.InvariantCulture));
    
                Console.Write("Replacement doing");
                for (int i = 0; i < _files.Count; i++)
                {
                    var fileInfo = _files[i];
                    Console.CursorLeft = 0;
                    Console.Write("{0} of {1}", i.ToString(CultureInfo.InvariantCulture), _files.Count.ToString(CultureInfo.InvariantCulture));
                    ReplaceInFile(fileInfo.FullName);
                }
                Console.CursorLeft = 0;
                Console.Write("Replacement done");
            }
    
            private static void SearchFilesInDirectories(DirectoryInfo dir)
            {
                if (!dir.Exists) return;
    
                foreach (DirectoryInfo subDirInfo in dir.GetDirectories())
                    SearchFilesInDirectories(subDirInfo);
    
                foreach (var fileInfo in dir.GetFiles())
                    _files.Add(fileInfo);
            }
    
            private static void CreateReplaceList()
            {
                _replaceList.Add("Color=\"#FFF78A09\"", "Color=\"{DynamicResource AccentColor}\"");
                _replaceList.Add("Color=\"{StaticResource ColorHot}\"", "Color=\"{DynamicResource AccentColor}\"");
                _replaceList.Add("Color=\"#FFCC0000\"", "Color=\"{DynamicResource AccentColor}\"");
                _replaceList.Add("To=\"#FFCC0000\"", "To=\"{DynamicResource AccentColor}\"");
                _replaceList.Add("To=\"#FFF78A09\"", "To=\"{DynamicResource AccentColor}\"");
                _replaceList.Add("Background=\"#FFF78A09\"", "Background=\"{DynamicResource Accent}\"");
                _replaceList.Add("Foreground=\"#FFF78A09\"", "Foreground=\"{DynamicResource Accent}\"");
                _replaceList.Add("BorderBrush=\"#FFF78A09\"", "BorderBrush=\"{DynamicResource Accent}\"");
                _replaceList.Add("Value=\"#FFF78A09\"", "Value=\"{DynamicResource Accent}\"");
                _replaceList.Add("Fill=\"#FFF78A09\"", "Fill=\"{DynamicResource Accent}\"");
            }
    
            public static void ReplaceInFile(string filePath)
            {
                string content;
                using (var reader = new StreamReader(filePath))
                {
                    content = reader.ReadToEnd();
                    reader.Close();
                }
    
                content = _replaceList.Aggregate(content, (current, item) => current.Replace(item.Key, item.Value));
    
                using (var writer = new StreamWriter(filePath))
                {
                    writer.Write(content);
                    writer.Close();
                }
            }
        }
    }
