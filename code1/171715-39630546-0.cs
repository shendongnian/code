      public static class FileInfoExtensions
        {
            /// <summary>
            /// behavior when new filename is exist.
            /// </summary>
            public enum FileExistBehavior
            {
                /// <summary>
                /// None: throw IOException "The destination file already exists."
                /// </summary>
                None = 0,
                /// <summary>
                /// Replace: replace the file in the destination.
                /// </summary>
                Replace = 1,
                /// <summary>
                /// Skip: skip this file.
                /// </summary>
                Skip = 2,
                /// <summary>
                /// Rename: rename the file. (like a window behavior)
                /// </summary>
                Rename = 3
            }
            /// <summary>
            /// Rename the file.
            /// </summary>
            /// <param name="fileInfo">the target file.</param>
            /// <param name="newFileName">new filename with extension.</param>
            /// <param name="fileExistBehavior">behavior when new filename is exist.</param>
            public static void Rename(this System.IO.FileInfo fileInfo, string newFileName, FileExistBehavior fileExistBehavior = FileExistBehavior.None)
            {
                string newFileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(newFileName);
                string newFileNameExtension = System.IO.Path.GetExtension(newFileName);
                string newFilePath = System.IO.Path.Combine(fileInfo.Directory.FullName, newFileName);
    
                if (System.IO.File.Exists(newFilePath))
                {
                    switch (fileExistBehavior)
                    {
                        case FileExistBehavior.None:
                            throw new System.IO.IOException("The destination file already exists.");
                        case FileExistBehavior.Replace:
                            System.IO.File.Delete(newFilePath);
                            break;
                        case FileExistBehavior.Rename:
                            int dupplicate_count = 0;
                            string newFileNameWithDupplicateIndex;
                            string newFilePathWithDupplicateIndex;
                            do
                            {
                                dupplicate_count++;
                                newFileNameWithDupplicateIndex = newFileNameWithoutExtension + " (" + dupplicate_count + ")" + newFileNameExtension;
                                newFilePathWithDupplicateIndex = System.IO.Path.Combine(fileInfo.Directory.FullName, newFileNameWithDupplicateIndex);
                            } while (System.IO.File.Exists(newFilePathWithDupplicateIndex));
                            newFilePath = newFilePathWithDupplicateIndex;
                            break;
                        case FileExistBehavior.Skip:
                            return;
                    }
                }
                System.IO.File.Move(fileInfo.FullName, newFilePath);
            }
        }
