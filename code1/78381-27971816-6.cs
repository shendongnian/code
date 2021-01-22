    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.IO.Compression.FileSystem;
    
    namespace ZipFileCreator
    {
        public static class ZipFileCreator
        {
            /// <summary>
            /// Create a ZIP file of the files provided.
            /// </summary>
            /// <param name="fileName">The full path and name to store the ZIP file at.</param>
            /// <param name="files">The list of files to be added.</param>
            public static void CreateZipFile(string fileName, IEnumerable<string> files)
            {
                // Create and open a new ZIP file
                var zip = ZipFile.Open(fileName, ZipArchiveMode.Create);
                foreach (var file in files)
                {
                    // Add the entry for each file
                    zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
                }
                // Dispose of the object when we are done
                zip.Dispose();
            }
        }
    }
