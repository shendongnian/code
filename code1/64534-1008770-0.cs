    char[] buffer = new char[10000];
    string renamedFile = file.FullName + ".orig";
    File.Move(file.FullName, renamedFile);
    using (StreamReader sr = new StreamReader(renamedFile))
    using (StreamWriter sw = new StreamWriter(file.FullName, false))
    {
        sw.Write("<root>");
        int read;
        while ((read = sr.Read(buffer, 0, buffer.Length)) > 0)
            sw.Write(buffer, 0, read);
        sw.Write("</root>");
    }
    File.Delete(renamedFile);
