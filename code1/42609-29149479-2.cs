    void File_DeleteLine(int Line, string Path)
    {
        StringBuilder sb = new StringBuilder();
        using (StreamReader sr = new StreamReader(Path))
        {
            int Countup = 0;
            while (!sr.EndOfStream)
            {
                Countup++;
                if (Countup != Line)
                {
                    using (StringWriter sw = new StringWriter(sb))
                    {
                        sw.WriteLine(sr.ReadLine());
                    }
                }
                else
                {
                    sr.ReadLine();
                }
            }
        }
        using (StreamWriter sw = new StreamWriter(Path))
        {
            sw.Write(sb.ToString());
        }
    }
