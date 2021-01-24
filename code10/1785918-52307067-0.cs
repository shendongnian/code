    // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            if (!File.Exists(destFile))
            {
                System.IO.File.Copy(sourceFile, destFile, true);
            }
            else
            {
                System.IO.File.Move(destFile, existingFilePath); //if file is existing and then move it to specific folder
                try
                {
                    System.IO.File.Copy(sourceFile, destFile, true);
                }
                catch (Exception)
                {
                    System.IO.File.Move(existingFilePath, destFile); //If anythig went wrong, old file is relocated correctly
                }
                System.IO.File.Delete(existingFilePath); // Delete old file, all is ok now.
            }
