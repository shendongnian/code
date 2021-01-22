public static string SanitizePath(string path, char replaceChar)
{
    int filenamePos = path.LastIndexOf(Path.DirectorySeparatorChar) + 1;
    var sb = new System.Text.StringBuilder();
    sb.Append(path.Substring(0, filenamePos));
    for (int i = filenamePos; i &lt; path.Length; i++)
    {
        char filenameChar = path[i];
        foreach (char c in Path.GetInvalidFileNameChars())
            if (filenameChar.Equals(c))
            {
                filenameChar = replaceChar;
                break;
            }
        sb.Append(filenameChar);
    }
    return sb.ToString();
}
