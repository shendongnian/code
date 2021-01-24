                StreamWriter sw = new StreamWriter(path, true);
                StreamReader sr = new StreamReader(tmpPath, true);
                bool inRewriteBlock = false;
    
                while ((s = sr.ReadLine()) != null)
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
