    using System;
    using System.IO;
    namespace ConsoleApplication
    {
      class Program
      {
        static void Main(string[] args)
        {
          string startPath = @"c:\example\start";
          string zipPath = @"c:\example\result.zip";
          string extractPath = @"c:\example\extract";
          System.IO.Compression.ZipFile.CreateFromDirectory(startPath, zipPath);
          System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
      }
    }
