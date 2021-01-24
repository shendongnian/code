     var imageFile = ConvertFileInByteArray(model.Image.InputStream, model.Image.ContentLength);
       private byte[] ConvertFileInByteArray(Stream inputStream, int contentLength)
        {
            try
            {
                byte[] file = null;
                using (var binaryReader = new BinaryReader(inputStream))
                {
                    file = binaryReader.ReadBytes(contentLength);
                }
                return file;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                Console.Write(e.ToString());
                throw;
            }
        }
        string imageStr = ComputeHash(imageFile);
        private string ComputeHash(byte[] file)
        {
            MD5 md5 = MD5.Create();
            byte[] hashAraay = md5.ComputeHash(file);
            var builder = new StringBuilder();
            foreach (byte b in hashAraay)
            {
                builder.AppendFormat("{0:x2}", b);
            }
            return builder.ToString();
        }
