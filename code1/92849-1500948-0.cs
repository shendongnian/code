    using (Stream stream = GetStreamFromSomewhere())
    {
        using (
            XmlDictionaryReader mtomReader = XmlDictionaryReader.CreateMtomReader(
                stream, Encoding.UTF8, XmlDictionaryReaderQuotas.Max))
        {
            string elementString = mtomReader.ReadElementString();
            byte[] elementBytes = Convert.FromBase64String(elementString);
            using (
                Stream elementFileStream =
                    new FileStream(tempFileLocation, FileMode.Create))
            {
                elementFileStream.Write(
                    elementBytes, 0, elementBytes.Length);
            }
            /// ...
            mtomReader.Close();
        }
    }
