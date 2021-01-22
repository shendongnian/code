    public static String SearchFileRecursive(String baseFolderPath, String fileName)
        {
            // Returns, if found, the full path of the file; otherwise returns null.
            var response = Path.Combine(baseFolderPath, fileName);
            if (File.Exists(response))
            {
                return response;
            }
            // Recursion.
            var directories = Directory.GetDirectories(baseFolderPath);
            for (var i = 0; i < directories.Length; i++)
            {
                response = SearchFileRecursive(directories[i], fileName);
                if (response != null) return response;
            }
            // { file was not found }
            return null;
        }
