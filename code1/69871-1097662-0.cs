    /// <summary>
    /// The commented methods are marked for future
    /// </summary>
    public interface IZipper
    {
        //void Create();
        void ExtractAll();
        void ExtractAll(string folder);
        //void Extract(string fileName);
        void AddFile(string fileName);
        //void DeleteFile(string fileName);
    }
    public interface IZipStreamProvider
    {
        Stream GetStream(string fileName);
    }
    public class ZipStreamProvider : IZipStreamProvider
    {
        public Stream GetStream(string fileName)
        {
            //Create a read/writable file
            return new FileStream(fileName, FileMode.Create);
        }
    }
    public class Zipper : IZipper
    {
        private const long BufferSize = 4096;
        public string ZipFileName { get; set;}
        //seam.. to use property injection
        private IZipStreamProvider ZipStreamProvider { get; set;}
        public Zipper(string zipFilename)
        {
            ZipFileName = zipFilename;
            //By default, write to file
            ZipStreamProvider = new ZipStreamProvider();
        }
        public void ExtractAll()
        {
            ExtractAll(Environment.CurrentDirectory);
        }
        public void ExtractAll(string folder)
        {
            using (var zip = System.IO.Packaging.Package.Open(ZipStreamProvider.GetStream(ZipFileName)))
            {
                foreach (var part in zip.GetParts())
                {
                    using (var reader = new StreamReader(part.GetStream(FileMode.Open, FileAccess.Read)))
                    {
                        using (var writer = ZipStreamProvider.GetStream(folder + "\\" + Path.GetFileName(part.Uri.OriginalString)))
                        {
                            var buffer = System.Text.Encoding.UTF8.GetBytes(reader.ReadToEnd());
                            writer.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
        public void AddFile(string fileToAdd)
        {
            using (var zip = System.IO.Packaging.Package.Open(ZipFileName, FileMode.OpenOrCreate))
            {
                var destFilename = ".\\" + Path.GetFileName(fileToAdd);
                var uri = PackUriHelper.CreatePartUri(new Uri(destFilename, UriKind.Relative));
                if (zip.PartExists(uri))
                {
                    zip.DeletePart(uri);
                }
                var part = zip.CreatePart(uri, "", CompressionOption.Normal);
                using (var fileStream = ZipStreamProvider.GetStream(fileToAdd))
                {
                    using (var dest = part.GetStream())
                    {
                        CopyStream(fileStream, dest);
                    }
                }
            }
        }
        private long CopyStream(Stream inputStream, Stream outputStream)
        {
            var bufferSize = inputStream.Length < BufferSize ? inputStream.Length : BufferSize;
            var buffer = new byte[bufferSize];
            int bytesRead;
            var bytesWritten = 0L;
            while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                outputStream.Write(buffer, 0, bytesRead);
                bytesWritten += bufferSize;
            }
            return bytesWritten;
        }
    }
