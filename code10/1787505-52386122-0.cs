    private Stopwatch sw = new Stopwatch();
    private FileInfo _sourceFile = new FileInfo(@"D:\source.txt");
    private FileInfo _destinationFile = new FileInfo(@"D:\destination.hex");
    
    private void ConvertFile()
    {
        sw.Start();
        using (var streamReader = new StreamReader(_sourceFile.OpenRead()))
        {
            using (var streamWrite = _destinationFile.OpenWrite())
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    if (line.Contains(" x"))
                    {
                        var array = ToByteArray(line);
                        streamWrite.Write(array, 0, array.Length);
                    }
                }
            }
        }
        sw.Stop();
        MessageBox.Show("Done in " + sw.Elapsed);
    }
    
    private byte[] ToByteArray(string hexString)
    {
        return hexString.ToList().ConvertAll(c => Convert.ToByte(c)).ToArray();
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ConvertFile();
    }
