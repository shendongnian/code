    ContentTypes.Register(MimeTypes.Xml,
        (req, dto, stream) => {
            using (var xw = XmlWriter.Create(stream))
            {
                var ser = new XmlSerializerWrapper(dto.GetType());
                ser.WriteObject(xw, dto);
            }
        },
        (type, stream) => {
            using (var reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas()))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(type);
                return serializer.Deserialize(reader);
            }                    
        });
