                    string currentContent = String.Empty;
                if (File.Exists(filePath))
                {
                    currentContent = File.ReadAllText(filePath);
                }
                File.WriteAllText(filePath, newContent + currentContent );
 
