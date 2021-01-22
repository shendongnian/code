                    string currentContent = String.Empty;
                if (File.Exists(RevertFilePath))
                {
                    currentContent = File.ReadAllText(RevertFilePath);
                }
                File.WriteAllText(RevertFilePath, newContent + currentContent );
 
