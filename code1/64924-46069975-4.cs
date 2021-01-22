    protected static Regex m_FtpListingRegex = new Regex(@"^([d-])((?:[rwxt-]{3}){3})\s+(\d{1,})\s+(\w+)?\s+(\w+)?\s+(\d{1,})\s+(\w+)\s+(\d{1,2})\s+(\d{4})?(\d{1,2}:\d{2})?\s+(.+?)\s?$",
                RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
    protected static readonly String Timeformat = "MMM dd yyyy HH:mm";
    /// <summary>
    /// Handles file info given in the form of a string in standard unix ls output format.
    /// </summary>
    /// <param name="filesListing">The file listing string.</param>
    /// <returns>A list of FtpFileInfo objects</returns>
    public static List<FtpFileInfo> GetFilesListFromFtpListingUnix(String filesListing)
    {
        List<FtpFileInfo> files = new List<FtpFileInfo>();
        MatchCollection matches = m_FtpListingRegex.Matches(filesListing);
        if (matches.Count == 0 && filesListing.Trim('\r','\n','\t',' ').Length != 0)
            return null; // parse error. Could throw some kind of exception here too.
        foreach (Match match in matches)
        {
            FtpFileInfo fileInfo = new FtpFileInfo();
            Char dirchar = match.Groups[1].Value.ToLowerInvariant()[0];
            fileInfo.IsDirectory = dirchar == 'd';
            fileInfo.Permissions = match.Groups[2].Value.ToCharArray();
            // No clue what "inodes" actually means...
            Int32 inodes;
            fileInfo.NrOfInodes = Int32.TryParse(match.Groups[3].Value, out inodes) ? inodes : 1;
            fileInfo.User = match.Groups[4].Success ? match.Groups[4].Value : null;
            fileInfo.Group = match.Groups[5].Success ? match.Groups[5].Value : null;
            Int64 fileSize;
            Int64.TryParse(match.Groups[6].Value, out fileSize);
            fileInfo.FileSize = fileSize;
            String month = match.Groups[7].Value;
            String day = match.Groups[8].Value.PadLeft(2, '0');
            String year = match.Groups[9].Success ? match.Groups[9].Value : DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
            String time = match.Groups[10].Success ? match.Groups[10].Value.PadLeft(5, '0') : "00:00";
            String timeString = month + " " + day + " " + year + " " + time;
            DateTime lastModifiedDate;
            if (!DateTime.TryParseExact(timeString, Timeformat, CultureInfo.InvariantCulture, DateTimeStyles.None, out lastModifiedDate))
                lastModifiedDate = DateTime.MinValue;
            fileInfo.LastModifiedDate = lastModifiedDate;
            fileInfo.FileName = match.Groups[11].Value;
            files.Add(fileInfo);
        }
        return files;
    }
