    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    namespace LoopCopy
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (args.Length != 2)
                {
                    Console.WriteLine(
                      "Usage: LoopCopy.exe SourceFile DestFile");
                    return;
                }
                string srcName = args[0];
                string destName = args[1];
                FileInfo sourceFile = new FileInfo(srcName);
                if (!sourceFile.Exists)
                {
                    Console.WriteLine("Source file {0} does not exist", 
                        srcName);
                    return;
                }
                long fileLen = sourceFile.Length;
                FileInfo destFile = new FileInfo(destName);
                if (destFile.Exists)
                {
                    Console.WriteLine("Destination file {0} already exists", 
                        destName);
                    return;
                }
                int buflen = 1024;
                byte[] buf = new byte[buflen];
                long totalBytesRead = 0;
                double pctDone = 0;
                string msg = "";
                int numReads = 0;
                Console.Write("Progress: ");
                using (FileStream sourceStream = 
                  new FileStream(srcName, FileMode.Open))
                {
                    using (FileStream destStream = 
                        new FileStream(destName, FileMode.CreateNew))
                    {
                        while (true)
                        {
                            numReads++;
                            int bytesRead = sourceStream.Read(buf, 0, buflen);
                            if (bytesRead == 0) break; 
                            destStream.Write(buf, 0, bytesRead);
                            totalBytesRead += bytesRead;
                            if (numReads % 10 == 0)
                            {
                                for (int i = 0; i < msg.Length; i++)
                                {
                                    Console.Write("\b \b");
                                }
                                pctDone = (double)
                                    ((double)totalBytesRead / (double)fileLen);
                                msg = string.Format("{0}%", 
                                         (int)(pctDone * 100));
                                Console.Write(msg);
                            }
                            if (bytesRead < buflen) break;
                        }
                    }
                }
                for (int i = 0; i < msg.Length; i++)
                {
                    Console.Write("\b \b");
                }
                Console.WriteLine("100%");
                Console.WriteLine("Done");
            }
        }
    }
