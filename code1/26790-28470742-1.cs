    /// <summary>
    /// Validate the Path. If path is relative append the path to the project directory by default.
    /// </summary>
    /// <param name="path">Path to validate</param>
    /// <param name="RelativePath">Relative path</param>
    /// <param name="Extension">If want to check for File Path</param>
    /// <returns></returns>
    private static bool ValidateDllPath(ref string path, string RelativePath = "", string Extension = "") {
        // Check if it contains any Invalid Characters.
        if (path.IndexOfAny(Path.GetInvalidPathChars()) == -1) {
            try {
                // If path is relative take %IGXLROOT% as the base directory
                if (!Path.IsPathRooted(path)) {
                    if (string.IsNullOrEmpty(RelativePath)) {
                        // Exceptions handled by Path.GetFullPath
                        // ArgumentException path is a zero-length string, contains only white space, or contains one or more of the invalid characters defined in GetInvalidPathChars. -or- The system could not retrieve the absolute path.
                        // 
                        // SecurityException The caller does not have the required permissions.
                        // 
                        // ArgumentNullException path is null.
                        // 
                        // NotSupportedException path contains a colon (":") that is not part of a volume identifier (for example, "c:\"). 
                        // PathTooLongException The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.
                        // RelativePath is not passed so we would take the project path 
                        path = Path.GetFullPath(RelativePath);
                    } else {
                        // Make sure the path is relative to the RelativePath and not our project directory
                        path = Path.Combine(RelativePath, path);
                    }
                }
                // Exceptions from FileInfo Constructor:
                //   System.ArgumentNullException:
                //     fileName is null.
                //
                //   System.Security.SecurityException:
                //     The caller does not have the required permission.
                //
                //   System.ArgumentException:
                //     The file name is empty, contains only white spaces, or contains invalid characters.
                //
                //   System.IO.PathTooLongException:
                //     The specified path, file name, or both exceed the system-defined maximum
                //     length. For example, on Windows-based platforms, paths must be less than
                //     248 characters, and file names must be less than 260 characters.
                //
                //   System.NotSupportedException:
                //     fileName contains a colon (:) in the middle of the string.
                FileInfo fileInfo = new FileInfo(path);
                // Exceptions using FileInfo.Length:
                //   System.IO.IOException:
                //     System.IO.FileSystemInfo.Refresh() cannot update the state of the file or
                //     directory.
                //
                //   System.IO.FileNotFoundException:
                //     The file does not exist.-or- The Length property is called for a directory.
                bool throwEx = fileInfo.Length == -1;
                // Exceptions using FileInfo.IsReadOnly:
                //   System.UnauthorizedAccessException:
                //     Access to fileName is denied.
                //     The file described by the current System.IO.FileInfo object is read-only.-or-
                //     This operation is not supported on the current platform.-or- The caller does
                //     not have the required permission.
                throwEx = fileInfo.IsReadOnly;
                if (!string.IsNullOrEmpty(Extension)) {
                    // Validate the Extension of the file.
                    if (Path.GetExtension(path).Equals(Extension, StringComparison.InvariantCultureIgnoreCase)) {
                        // Trim the Library Path
                        path = path.Trim();
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return true;
                }
            } catch (ArgumentNullException) {
                //   System.ArgumentNullException:
                //     fileName is null.
            } catch (System.Security.SecurityException) {
                //   System.Security.SecurityException:
                //     The caller does not have the required permission.
            } catch (ArgumentException) {
                //   System.ArgumentException:
                //     The file name is empty, contains only white spaces, or contains invalid characters.
            } catch (UnauthorizedAccessException) {
                //   System.UnauthorizedAccessException:
                //     Access to fileName is denied.
            } catch (PathTooLongException) {
                //   System.IO.PathTooLongException:
                //     The specified path, file name, or both exceed the system-defined maximum
                //     length. For example, on Windows-based platforms, paths must be less than
                //     248 characters, and file names must be less than 260 characters.
            } catch (NotSupportedException) {
                //   System.NotSupportedException:
                //     fileName contains a colon (:) in the middle of the string.
            } catch (FileNotFoundException) {
                // System.FileNotFoundException
                //  The exception that is thrown when an attempt to access a file that does not
                //  exist on disk fails.
            } catch (IOException) {
                //   System.IO.IOException:
                //     An I/O error occurred while opening the file.
            } catch (Exception) {
                // Unknown Exception. Might be due to wrong case or nulll checks.
            }
        } else {
            // Path contains invalid characters
        }
        return false;
    }
