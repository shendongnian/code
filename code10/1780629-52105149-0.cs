    StreamWriter SaveFile = new StreamWriter(sPath);
    foreach (var item in listBox1.Items)
    {
       SaveFile.WriteLine(item);
    }
    SaveFile.ToString();
    SaveFile.Close();
