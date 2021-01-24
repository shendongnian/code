    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.IO;
    using System.Web;
    
    namespace MD5_Generator
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                Console.WriteLine("MD5 Hash Generator");
                Console.WriteLine("This program creates MD5 hashes for all files in the folder.");
                Console.WriteLine("Work in progress...");
                string root = Directory.GetCurrentDirectory();
                string hashList = root + "/hashList.txt";            
                if (!File.Exists(hashList))
                {
                    var initHastListFile = File.Create(hashList);
                    initHastListFile.Close();
                }
                else
                {
                    File.Delete(hashList);
                    var hastListFile = File.Create(hashList);
                    hastListFile.Close();
                }
                int i = 0;
                string[] allFiles = Directory.GetFiles(root, "*.*", SearchOption.AllDirectories);
                string[] lines = new string[allFiles.Count()];
    
                lines = DirSearch(root, lines, i, root);
                File.AppendAllLines(hashList, lines);
    
                Console.ReadKey();
    
            }
    
            static string[] DirSearch(string dir, string[] lines, int counter, string root)
            {
                string hashListFileName = "hashList.txt";
                foreach (string f in Directory.GetFiles(dir))
                {
                    //2. Create an MD5 hash per file
                    using (var md5 = MD5.Create())
                    {
                        FileInfo info = new FileInfo(f);
                        string filename = info.FullName;
                        if (filename != hashListFileName)
                        {
                            using (var stream = File.OpenRead(filename))
                            {
                                byte[] fileMD5 = md5.ComputeHash(stream);
                                string hash = HttpServerUtility.UrlTokenEncode(fileMD5);
                                string currDir = Path.GetDirectoryName(filename);                         
                                lines[counter] = info.FullName.Substring(root.Length+1) + " " + hash;                            
                            }
                            counter++;
                        }
                    }
                }
    
                foreach (string d in Directory.GetDirectories(dir))
                {
                    DirSearch(d, lines, counter, root);
                }
    
                return lines;
            }
        }
    }
