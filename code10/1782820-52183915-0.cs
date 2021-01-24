    using System;
    using System.IO;
    using System.IO.Compression;
    namespace ZipTest
    {
      internal static class Program
      {
        private static void Main()
        {
          var fileList = new[] { @"d:\Test\file1", @"d:\Test\file2", @"d:\Test\file3", @"d:\Test\file4",
            @"d:\Test\file5", @"d:\Test\file6", @"d:\Test\file7", @"d:\Test\file8", @"d:\Test\file9", @"d:\Test\file10" };
          using (var MyZipArchive = ZipFile.Open(@"d:\Test\Test.zip", ZipArchiveMode.Update))
          {
            foreach (var f in fileList)
            {
              Console.WriteLine("Compressing: " + f);
              MyZipArchive.CreateEntryFromFile(f, Path.GetFileName(f), CompressionLevel.Fastest);
            }
          }
        }
      }
    }
