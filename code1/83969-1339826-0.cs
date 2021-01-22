        public static void RemoveLines(Predicate<string> removeFunction,string file){
            string line, tempFile = null;
            try{
                tempFile = Path.GetTempFileName();
                using (StreamReader sr = new StreamReader(file))
                using (StreamWriter sw = new StreamWriter(tempFile,false,sr.CurrentEncoding))
                    while ((line = sr.ReadLine()) != null)
                        if (!removeFunction(line)) sw.WriteLine(line);
                File.Delete(file);
                File.Move(tempFile, file);
            }finally{
                if(tempFile != null && File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }
