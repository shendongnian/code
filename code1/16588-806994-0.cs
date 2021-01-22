    /// <summary>
    /// Tries to open a file, with a user defined number of attempt and Sleep delay between attempts.
    /// </summary>
    /// <param name="filePath">The full file path to be opened</param>
    /// <param name="fileMode">Required file mode enum value(see MSDN documentation)</param>
    /// <param name="fileAccess">Required file access enum value(see MSDN documentation)</param>
    /// <param name="fileShare">Required file share enum value(see MSDN documentation)</param>
    /// <param name="maximumAttempts">The total number of attempts to make (multiply by attemptWaitMS for the maximum time the function with Try opening the file)</param>
    /// <param name="attemptWaitMS">The delay in Milliseconds between each attempt.</param>
    /// <returns>A valid FileStream object for the opened file, or null if the File could not be opened after the required attempts</returns>
    public FileStream TryOpen(string filePath, FileMode fileMode, FileAccess fileAccess,FileShare fileShare,int maximumAttempts,int attemptWaitMS)
    {
        FileStream fs = null;
        int attempts = 0;
        // Loop allow multiple attempts
        while (true)
        {
            try
            {
                fs = File.Open(filePath, fileMode, fileAccess, fileShare);
                
                //If we get here, the File.Open succeeded, so break out of the loop and return the FileStream
                break;
            }
            catch (IOException ioEx)
            {
                // IOExcception is thrown if the file is in use by another process.
                
                // Check the numbere of attempts to ensure no infinite loop
                attempts++;
                if (attempts > maximumAttempts)
                {
                    // Too many attempts,cannot Open File, break and return null 
                    fs = null;
                    break;
                }
                else
                {
                    // Sleep before making another attempt
                    Thread.Sleep(attemptWaitMS);
                }
            }
        }
        // Reutn the filestream, may be valid or null
        return fs;
    }
