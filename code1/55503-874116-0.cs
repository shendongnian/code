    object[][] ConvertFile(string csvOrXlsFile)
    {
        var output = System.IO.Path.GetTempFileName();
        try
        {
            var startinfo = new System.Diagnostics.ProcessStartInfo("convert.exe",
                string.Format("\"{0}\" \"{1}\"", csvOrXlsFile, output));
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = startinfo;
            proc.Start();
            proc.WaitForExit();
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(object[][]));
            using (var reader = System.IO.File.OpenText(output))
                return (object[][])serializer.Deserialize(reader);
        }
        finally
        {
            if (System.IO.File.Exists(output))
                System.IO.File.Delete(output);
        }
    }
