    - SuppressMessageAttribute
    That suppresses reporting of a specific static analysis tool rule violation, allowing multiple suppressions on a single code artifact.
    For example:
    [SuppressMessage("Microsoft.Performance", "CA1801:ReviewUnusedParameters", MessageId = "isChecked")]
    [SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "fileIdentifier")]
    static void FileNode(string name, bool isChecked)
    {
        string fileIdentifier = name;
        string fileName = name;
        string version = String.Empty;
    }
 
