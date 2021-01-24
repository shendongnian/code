    using System.IO;
    using System.Linq;
    
    
    namespace ASCII_Split
    {
        class Program
        {
            static void Main(string[] args)
            {
                var txt = "";
                const char soh = (char)1;
                const char eox = (char)3;
                var count = 1;
                var pathToFile = @"C:\Temp\00599060.txt";
    
                using (var sr = new StreamReader (pathToFile))
                    txt = sr.ReadToEnd();
    
                if (txt.IndexOf(soh) != txt.LastIndexOf(soh))
                {
                   
    
                    while (txt.Contains(soh))
                    {
                        var outfil = Path.Combine(Path.GetDirectoryName(pathToFile), count.ToString("00") + Path.GetFileName(pathToFile));
                        var eInd = txt.IndexOf(eox);
                        using (var sw = new StreamWriter(outfil, false))
                        {
                            sw.Write(txt.Substring(1, eInd - 1));
                        }
                        txt = txt.Substring(eInd + 1);
                        count++;
                    }
                    File.Move((pathToFile), (pathToFile) + ".org");
                }
            }
        }
    }
