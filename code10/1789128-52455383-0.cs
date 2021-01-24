    using System;
    using System.IO;
    using System.IO.Compression;
    using ICSharpCode.SharpZipLib.Zip;
    using DotNetZipFile = System.IO.Compression.ZipFile;
    namespace Stackoverflow_unzip_test
    {
      internal static class Program
      {
        private static void Main()
        {
          Extract45Framework("CRCerror.zip", ".\\Unpack_1");
          Console.WriteLine();
          Console.WriteLine();
          ExtractSharpZipLib("CRCerror.zip", ".\\Unpack_2");
        }
        private static void Extract45Framework(string zipFile, string extractPath)
        {
          ZipArchive zipArchive = DotNetZipFile.OpenRead(zipFile);
          if (zipArchive.Entries != null && zipArchive.Entries.Count > 0)
          {
            Console.WriteLine("Extracting...");
            foreach (ZipArchiveEntry entry in zipArchive.Entries)
            {
              try
              {
                if (string.IsNullOrEmpty(entry.Name))
                {
                  // skip directory
                  continue;
                }
                string file = Path.Combine(extractPath, entry.FullName);
                string path = Path.GetDirectoryName(file);
                if (!Directory.Exists(path))
                {
                  Directory.CreateDirectory(path);
                }
                Console.WriteLine(" - '" + entry.FullName + "'...");
                if (File.Exists(file))
                {
                  //Console.WriteLine("   - delete previous version...");
                  File.Delete(file);
                }
                entry.ExtractToFile(file);
                long length = (new FileInfo(file)).Length;
                if (entry.Length != length)
                {
                  Console.WriteLine($"   - Failed to extract! Extracted only {length} out of {entry.Length} bytes");
                }
              }
              catch (Exception ex)
              {
                Console.WriteLine("   - Failed to extract: " + ex.Message);
              }
            }
          }
        }
        private static void ExtractSharpZipLib(string zipFileName, string extractPath)
        {
          using (var file = File.OpenRead(zipFileName))
          using (ZipInputStream zip = new ZipInputStream(file))
          {
            ZipEntry entry;
            try
            {
              while ((entry = zip.GetNextEntry()) != null)
              {
                SaveFile(zip, entry, extractPath);
              }
            }
            catch (Exception ex)
            {
              Console.WriteLine("   - Failed to parse zip: " + ex.Message);
            }
          }
        }
        private static void SaveFile(ZipInputStream zip, ZipEntry entry, string extractPath)
        {
          if (entry.IsDirectory)
          {
            return;
          }
          try
          {
            string file = Path.Combine(extractPath, entry.Name);
            string path = Path.GetDirectoryName(file);
            if (!Directory.Exists(path))
            {
              Directory.CreateDirectory(path);
            }
            Console.WriteLine(" - '" + entry.Name + "'...");
            if (File.Exists(file))
            {
              //Console.WriteLine("   - delete previous version...");
              File.Delete(file);
            }
            byte[] data = new byte[1024];
            long length = 0;
            using (var fs = File.OpenWrite(file))
            {
              int readLength;
              while ((readLength = zip.Read(data, 0, data.Length)) != 0)
              {
                fs.Write(data, 0, readLength);
                length += readLength;
              }
            }
            if (entry.Size != length)
            {
              Console.WriteLine($"   - Failed to extract! Extracted only {length} out of {entry.Size} bytes");
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine("   - Failed to extract: " + ex.Message);
          }
        }
      }
    }
