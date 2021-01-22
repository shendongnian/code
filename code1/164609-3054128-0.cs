    static void Main(string[] args)
        {
            FileInfo f = new FileInfo("C:/temp/Arungg.txt");
            StreamWriter Tex = f.Exists ? f.AppendText() : f.CreateText();
            Tex.WriteLine("Test1");
            Tex.WriteLine("Test2");
            Tex.Write(Tex.NewLine);
            Tex.Close();
            Console.WriteLine(" The Text file named Arungg is created ");
        }
