    string[] validExt = {".xls",".xlsx"};
    string extension = System.IO.Path.GetExtension(openFileDialog1.FileName);
    bool fileValid = validExt.Contains(extension, StringComparer.InvariantCultureIgnoreCase);
    if(!fileValid)
    {
       // ...
    }
