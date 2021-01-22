    static void writeData(Object line)
    {
                string filename = String.Format("file{0}.txt", ++i);
                File.WriteAllText(filename, line);
    }
