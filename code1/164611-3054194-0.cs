            var f = new FileInfo(@"c:\temp\Arungg.txt");
            var writer = f.Exists ? f.AppendText() : new StreamWriter(f.OpenWrite());
            using (writer)
            {
                writer.WriteLine("Test1");
                writer.WriteLine("Test2");
                writer.WriteLine(); // No need for NewLine
            }
