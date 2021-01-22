     /// <summary>
            /// Convert the Binary AnyFile to Byte[] format
            /// </summary>
            /// <param name="image"></param>
            /// <returns></returns>
            public static byte[] ConvertANYFileToBytes(HttpPostedFileBase image)
            {
                byte[] imageBytes = null;
                BinaryReader reader = new BinaryReader(image.InputStream);
                imageBytes = reader.ReadBytes((int)image.ContentLength);
                return imageBytes;
            }
