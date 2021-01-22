        public static void Main(string[] args)
        {
            try
            {
                var dir = @"C:\Test";
                //Get all html and htm files
                var files = DirSearch(dir);
                foreach (var file in files)
                {
                    RmCode(file);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        private static void RmCode(string file)
        {
            string tempFile = Path.GetTempFileName();
            using (var sr = new StreamReader(file, Encoding.UTF8))
            using (var sw = new StreamWriter(new FileStream(tempFile, FileMode.Open, FileAccess.ReadWrite), Encoding.UTF8))
            {
                string line;
                var startOfBadCode = "<div>";
                var endOfBadCode = "</div>";
                var deleteLine = false;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(startOfBadCode))
                    {
                        deleteLine = true;
                    }
                    if (!deleteLine)
                    {
                        sw.WriteLine(line);
                    }
                    if (line.Contains(endOfBadCode))
                    {
                        deleteLine = false;
                    }
                }
            }
            File.Delete(file);
            File.Move(tempFile, file);
        }
        private static List<String> DirSearch(string sDir)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d));
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
            return files.Where(s => s.EndsWith(".htm") || s.EndsWith(".html")).ToList();
        }
