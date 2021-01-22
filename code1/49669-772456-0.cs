          foreach (FileInfo f in new DirectoryInfo(".").GetFiles())
            {
                if (f.Extension.ToUpperInvariant() == ".JPG"
                    || f.Extension.ToUpperInvariant() == ".JPEG")
                {
                    Image image = Image.FromFile(f.FullName);
                    if (image.RawFormat == ImageFormat.Jpeg)
                    {
                        Console.WriteLine(f.FullName + " is a Jpeg image");
                    }
                }
            }
