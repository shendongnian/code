            public const long BUFFER_SIZE = 4096;
        public static void AddFileToZip(string zipFilename, string fileToAdd)
        {
            using (Package zip = global::System.IO.Packaging.Package.Open(zipFilename, FileMode.OpenOrCreate))
            {
                string destFilename = ".\\" + Path.GetFileName(fileToAdd);
                Uri uri = PackUriHelper.CreatePartUri(new Uri(destFilename, UriKind.Relative));
                if (zip.PartExists(uri))
                {
                    zip.DeletePart(uri);
                }
                PackagePart part = zip.CreatePart(uri, "", CompressionOption.Normal);
                using (FileStream fileStream = new FileStream(fileToAdd, FileMode.Open, FileAccess.Read))
                {
                    using (Stream dest = part.GetStream())
                    {
                        CopyStream(fileStream, dest);
                    }
                }
            }
        }
        public static void CopyStream(global::System.IO.FileStream inputStream, global::System.IO.Stream outputStream)
        {
            long bufferSize = inputStream.Length < BUFFER_SIZE ? inputStream.Length : BUFFER_SIZE;
            byte[] buffer = new byte[bufferSize];
            int bytesRead = 0;
            long bytesWritten = 0;
            while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                outputStream.Write(buffer, 0, bytesRead);
                bytesWritten += bytesRead;
            }
        }
        public static void RemoveFileFromZip(string zipFilename, string fileToRemove)
        {
            using (Package zip = global::System.IO.Packaging.Package.Open(zipFilename, FileMode.OpenOrCreate))
            {
                string destFilename = ".\\" + fileToRemove;
                Uri uri = PackUriHelper.CreatePartUri(new Uri(destFilename, UriKind.Relative));
                if (zip.PartExists(uri))
                {
                    zip.DeletePart(uri);
                }
            }
        }
        public static void Remove_Content_Types_FromZip(string zipFileName)
        {
            string contents;
            using (ZipFile zipFile = new ZipFile(File.Open(zipFileName, FileMode.Open)))
            {
                /*
                ZipEntry startPartEntry = zipFile.GetEntry("[Content_Types].xml");
                using (StreamReader reader = new StreamReader(zipFile.GetInputStream(startPartEntry)))
                {
                    contents = reader.ReadToEnd();
                }
                XElement contentTypes = XElement.Parse(contents);
                XNamespace xs = contentTypes.GetDefaultNamespace();
                XElement newDefExt = new XElement(xs + "Default", new XAttribute("Extension", "sab"), new XAttribute("ContentType", @"application/binary; modeler=Acis; version=18.0.2application/binary; modeler=Acis; version=18.0.2"));
                contentTypes.Add(newDefExt);
                contentTypes.Save("[Content_Types].xml");
                zipFile.BeginUpdate();
                zipFile.Add("[Content_Types].xml");
                zipFile.CommitUpdate();
                File.Delete("[Content_Types].xml");
                */
                zipFile.BeginUpdate();
                try
                {
                    zipFile.Delete("[Content_Types].xml");
                    zipFile.CommitUpdate();
                }
                catch{}
            }
        }
