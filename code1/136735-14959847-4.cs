            public void ExportToFile(string path)
        {
            bool abort = false;
            bool exists = false;
            do
            {
                exists = File.Exists(path);
                if (!exists)
                {
                    if( !Convert.ToBoolean( File.CreateText(path) ) )
                            abort = true;
                }
            } while (!exists || abort);
            if (!abort)
            {
                //File.OpenWrite(path);
                using (StreamWriter w = File.AppendText(path))
                {
                    w.WriteLine("hello");
                }
            }
            //File.WriteAllText(path, Export());
        }
