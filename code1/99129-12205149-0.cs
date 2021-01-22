    <snip>
    using System.IO;
    <snip>
    FileInfo fi = new FileInfo(uri); //uri is the full path and file name
    if (fi.Attributes.HasFlag(FileAttributes.Encrypted))
    {
    //FILE IS ENCRYPTED
    }
    else
    {
    //FILE IS SAFE
    }
