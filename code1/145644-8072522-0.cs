        public T ConvertType<T>(object input)
        {
            XmlSerializer serializer = new XmlSerializer(input.GetType());
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, input);
            }
            using (StringReader sr = new StringReader(sb.ToString()))
            {
                return (T)deserializer.Deserialize(sr);
            }
        }
