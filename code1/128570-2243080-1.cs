    using System;
    using System.Collections.Generic;
    using System.IO;
    List<FileStream> files = new List<FileStream>();
    foreach (string file in Directory.GetFiles("yourPath"))
    {
        files.Add(new FileStream(file, FileMode.Open, FileAccess.ReadWrite));
    }
