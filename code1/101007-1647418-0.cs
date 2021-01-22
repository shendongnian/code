        var newfile = System.IO.File.CreateText("newcode.txt");
        newfile.Write("string[] list = { ");
        using (var file = System.IO.File.OpenText("code.txt"))
        {
            bool bFirst = true;
            while (!file.EndOfStream)
            {
                String line = file.ReadLine();
                if (line.Contains("case ") && line.EndsWith(":"))
                {
                    line = line.Replace("case", " ");
                    line = line.Replace(":", " ");
                    line = line.Trim();
                    if (bFirst == false)
                    {
                        newfile.Write(", ");
                    }
                    bFirst = false;
                    newfile.Write(line);
                }
            }
        }
        newfile.WriteLine(" };");
        newfile.Close();
