    /// <summary>
        /// Check if StorageFile is locked. Return true if locked, false otherwise.
        /// </summary>
        /// <param name="StorageFileToCheck">StorageFile to check if locked.</param>
        /// <returns></returns>
        public static async Task<Boolean> StorageFileLocked(StorageFile StorageFileToCheck)
        {
            // If StorageFileToCheck can't be deleted, then rename attempt will cause System.UnauthorizedAccessException indicating StorageFileToCheck is locked.
            string stringFilenameTemp = Guid.NewGuid().ToString("N") + StorageFileToCheck.FileType;
            string stringFilenameOrig = StorageFileToCheck.Name;
            Debug.WriteLine($"StorageFileLocked(): stringFoldernameTemp={stringFilenameTemp}");
            Debug.WriteLine($"StorageFileLocked(): stringFoldernameOrig={stringFilenameOrig}");
            try
            {
                // Try to rename file. If file is locked, then System.UnauthorizedAccessException will occur.
                await StorageFileToCheck.RenameAsync(stringFilenameTemp);
                await StorageFileToCheck.RenameAsync(stringFilenameOrig);     // Restore original name if no excpetion.
                Debug.WriteLine($"StorageFileLocked(): Returned false since no exception.");
                return false;   // Return false since no exception. File is not locked.
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"StorageFileLocked(): Returned true since exception occurred. Type={ex.GetType()}");
                return true;    // Return true since exception. File is locked.
            }
        }
        /// <summary>
        /// Check if StorageFolder is locked. Return true if locked, false otherwise.
        /// </summary>
        /// <param name="StorageFolderToCheck">StorageFolder to check if locked.</param>
        /// <returns></returns>
        public static async Task<Boolean> StorageFolderLocked(StorageFolder StorageFolderToCheck)
        {
            // If StorageFolderToCheck can't be deleted, then rename attempt will cause System.UnauthorizedAccessException indicating StorageFolderToCheck is locked.
            string stringFoldernameTemp = Guid.NewGuid().ToString("N");
            string stringFoldernameOrig = StorageFolderToCheck.Name;
            Debug.WriteLine($"StorageFolderLocked(): stringFoldernameTemp={stringFoldernameTemp}");
            Debug.WriteLine($"StorageFolderLocked(): stringFoldernameOrig={stringFoldernameOrig}");
            try
            {
                // Try to rename folder. If folder is locked, then System.UnauthorizedAccessException will occur.
                await StorageFolderToCheck.RenameAsync(stringFoldernameTemp);
                await StorageFolderToCheck.RenameAsync(stringFoldernameOrig);     // Restore original name if no excpetion.
                Debug.WriteLine($"StorageFolderLocked(): Returned false since no exception.");
                return false;   // Return false since no exception. Folder is not locked.
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"StorageFolderLocked(): Returned true since exception occurred. Type={ex.GetType()}");
                return true;    // Return true since exception. Folder is locked.
            }
        }
