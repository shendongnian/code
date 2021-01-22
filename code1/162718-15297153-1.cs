    /// <summary>
    /// Include a '/' before your filename, and ensure you include the file extension, ex. "/myFile.txt"
    /// </summary>
    /// <param name="filename"></param>
    /// <returns>True if it is empty, false if it is not empty</returns>
    private Boolean CheckIfFileIsEmpty(string filename)
    {
        var fileToTest = new FileInfo(Environment.CurrentDirectory + filename);
        return fileToTest.Length == 0;
    }
