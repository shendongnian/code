                //Read all text lines first
            string[] readText = File.ReadAllLines(path);
            //Open the text file to write
            var oStream = new FileStream(path, FileMode.Truncate, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new System.IO.StreamWriter(oStream);
            bool inRewriteBlock = false;
            foreach (var s in readText)
            {
                if (s.Trim() == "#Start")
                {
                    inRewriteBlock = true;
                    sw.WriteLine(s);
                }
                else if (s.Trim() == "#End")
                {
                    inRewriteBlock = false;
                    sw.WriteLine(s);
                }
                else if (inRewriteBlock)
                {
                    //REWRITE DATA HERE (IN THIS CASE IS DELETE LINE THEN DO NOTHING)
                }
                else
                {
                    sw.WriteLine(s);
                }
            }
            sw.Close();
