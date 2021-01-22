            public static void CopyAndReplaceAll(string SourcePath, string DestinationPath, string backupPath)
        {
                foreach (string dirPath in Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory($"{DestinationPath}{dirPath.Remove(0, SourcePath.Length)}");
                    Directory.CreateDirectory($"{backupPath}{dirPath.Remove(0, SourcePath.Length)}");
                }
                foreach (string newPath in Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories))
                {
                    if (!File.Exists($"{ DestinationPath}{newPath.Remove(0, SourcePath.Length)}"))
                        File.Copy(newPath, $"{ DestinationPath}{newPath.Remove(0, SourcePath.Length)}");
                    else
                        File.Replace(newPath
                            , $"{ DestinationPath}{newPath.Remove(0, SourcePath.Length)}"
                            , $"{ backupPath}{newPath.Remove(0, SourcePath.Length)}", false);
                }
        }
