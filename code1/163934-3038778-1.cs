    using System.Collections.Generic;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Linq;
    public static class IsolatedStorageFileExtensions
    {
 
        /// <summary>
        /// Recursively gets a list of all files in isolated storage
        /// </summary>
        /// <remarks>Based on <see cref="http://dotnetperls.com/recursively-find-files"/></remarks>
        /// <param name="isolatedStorageFile"></param>
        /// <returns></returns>
        public static List<string> GetAllFilePaths(this IsolatedStorageFile isolatedStorageFile)
        {
            // Store results in the file results list
            List<string> result = new List<string>();
 
            // Store a stack of our directories
            Stack<string> stack = new Stack<string>();
 
            // Add initial directory
            string initialDirectory = "*";
            stack.Push(initialDirectory);
 
            // Continue while there are directories to process
            while (stack.Count > 0)
            {
                // Get top directory
                string dir = stack.Pop();
 
                string directoryPath;
                if (dir == "*")
                {
                    directoryPath = "*";
                }
                else
                {
                    directoryPath = dir + @"\*";
                }
 
                // Add all files at this directory to the result List
                var filesInCurrentDirectory = isolatedStorageFile.GetFileNames(directoryPath).ToList<string>();
 
                List<string> filesInCurrentDirectoryWithFolderName = new List<string>();
 
                // Prefix the filename with the directory name
                foreach (string file in filesInCurrentDirectory)
                {
                    filesInCurrentDirectoryWithFolderName.Add(Path.Combine(dir, file));
                }
 
                result.AddRange(filesInCurrentDirectoryWithFolderName);
 
                // Add all directories at this directory
                foreach (string directoryName in isolatedStorageFile.GetDirectoryNames(directoryPath))
                {
                    stack.Push(directoryName);
                }
 
            }
 
            return result;
 
        }
 
    }
