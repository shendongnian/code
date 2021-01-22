    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo[] fileList = new FileInfo[] {
                new FileInfo("AWS025.sv2i"),
                new FileInfo("AWS025_C_Drive038.v2i"),
                new FileInfo("AWS025_C_Drive038_i001.iv2i"),
                new FileInfo("AWS025_C_Drive038_i002.iv2i"),
                new FileInfo("AWS025_C_Drive038_i003.iv2i"),
                new FileInfo("AWS025_C_Drive038_i004.iv2i"),
                new FileInfo("AWS025_C_Drive038_i005.iv2i")
            };
    
            Regex regex = new Regex(@"^.*(?<Backup>_\w_Drive(?<ImageNumber>\d+)(?<Increment>_i(?<IncrementNumber>\d+))?)\.[^.]+$");
            var results = from file in fileList
                          let match = regex.Match(file.Name)
                          let IsMainBackup = !match.Groups["Increment"].Success
                          let ImageNumber = match.Groups["ImageNumber"].Value
                          let IncrementNumber = match.Groups["IncrementNumber"].Value
                          where match.Groups["Backup"].Success
                          orderby file.CreationTime
                          select new { file.Name, file.CreationTime,
                                       IsMainBackup, ImageNumber, IncrementNumber };
    
            foreach (var x in results)
            {
                Console.WriteLine("Name: {0}, Main: {1}, Image: {2}, Increment: {3}",
                    x.Name, x.IsMainBackup, x.ImageNumber, x.IncrementNumber);
            }
        }
    }
