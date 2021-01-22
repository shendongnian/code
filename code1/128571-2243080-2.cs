    using System;
    using System.Collections.Generic;
    using System.IO;
    List<String> files = new List<String>();
    foreach (string file in Directory.GetFiles("yourPath"))
    {
        files.Add(file);
    }
