      using (StreamReader sr = new StreamReader(this._path))
            {
                string line = "";
                while(( line= sr.ReadLine()) != null)
                {
                    string[] cells = line.Split(new string[] { "\t" }, StringSplitOptions.None);
                    if (cells.Length > 0)
                    {
                    }
                }
            }
