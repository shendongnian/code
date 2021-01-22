    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Drawing;
    
    namespace SharpLibrary_MediaManager
    {
        public abstract class BaseFile
        {
            public string Name { get; set; }
            public string FileType { get; set; }
            public long Size { get; set; }
            public DateTime CreationDate { get; set; }
            public DateTime ModificationDate { get; set; }
    
            public abstract void getFileInformation(string filePath);
    
        }
    
    
        public class Picture : BaseFile
        {
            public int Height { get; set; }
            public int Width { get; set; }
            public Image Thumbnail { get; set; }
    
            public override void getFileInformation(string filePath)
            {
                FileInfo fileInformation = new FileInfo(filePath);
    
                using (var image = Image.FromFile(filePath))
                {
                    if (fileInformation.Exists)
                    {
                        Name = fileInformation.Name;
                        FileType = fileInformation.Extension;
                        Size = fileInformation.Length;
                        CreationDate = fileInformation.CreationTime;
                        ModificationDate = fileInformation.LastWriteTime;
                        Height = image.Height;
                        Width = image.Width;
                        Thumbnail = image.GetThumbnailImage(40, 40, null, new IntPtr());
                    }
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                string folderPath = @"C:\Users\arthur\Pictures";
    
                DirectoryInfo folder = new DirectoryInfo(folderPath);
                List<Picture> lol = new List<Picture>();
                double totalFileSize = 0;
                int counter = 0;
                foreach (FileInfo x in folder.GetFiles("*.jpg", SearchOption.AllDirectories))
                {
                    Picture p = new Picture();
                    p.getFileInformation(x.FullName);
                    lol.Add(p);
                    totalFileSize += p.Size;
                    Console.WriteLine("{0}: Total Size = {1:n2} MB", ++counter, totalFileSize / 1048576.0);
                }
    
                foreach (var p in lol)
                {
                    Console.WriteLine("{0}: {1}x{2} px", p.Name, p.Width, p.Height);
                }
            }
        }
    }
