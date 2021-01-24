        public static void Copy(string sourceDir, string targetDir)
        {
            foreach (var file in Directory.GetFiles(sourceDir))
            {
                File.Copy(file, Path.Combine(targetDir, Path.GetFileName(sourceDir)));
            }
            foreach (var _sourceDir in Directory.GetDirectories(sourceDir))
            {
                var _targetPath = Path.Combine(
                            targetDir,
                            Path.GetDirectoryName(_sourceDir));
                if (!Directory.Exists(_targetPath))
                {
                    Directory.CreateDirectory(_targetPath);
                }
                FileOps.Copy(_sourceDir, _targetPath);
            }
        }            
