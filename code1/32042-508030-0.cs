    using System;
    using System.IO;
    using System.IO.Packaging;
    using System.Text;
    
    class ExtractPackagedImages
    {
        static void Main(string[] paths)
        {
            foreach (string path in paths)
            {
                using (Package package = Package.Open(
                    path, FileMode.Open, FileAccess.Read))
                {
                    DirectoryInfo dir = Directory.CreateDirectory(path + " Images");
                    foreach (PackagePart part in package.GetParts())
                    {
                        if (part.ContentType.ToLowerInvariant().StartsWith("image/"))
                        {
                            string target = Path.Combine(
                                dir.FullName, CreateFilenameFromUri(part.Uri));
                            using (Stream source = part.GetStream(
                                FileMode.Open, FileAccess.Read))
                            using (Stream destination = File.OpenWrite(target))
                            {
                                byte[] buffer = new byte[0x1000];
                                int read;
                                while ((read = source.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    destination.Write(buffer, 0, read);
                                }
                            }
                            Console.WriteLine("Extracted {0}", target);
                        }
                    }
                }
            }
            Console.WriteLine("Done");
        }
    
        private static string CreateFilenameFromUri(Uri uri)
        {
            char [] invalidChars = Path.GetInvalidFileNameChars();
            StringBuilder sb = new StringBuilder(uri.OriginalString.Length);
            foreach (char c in uri.OriginalString)
            {
                sb.Append(Array.IndexOf(invalidChars, c) < 0 ? c : '_');
            }
            return sb.ToString();
        }
    }
