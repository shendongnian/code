        private static string DataContractSerialize(object obj)
        {
            StringWriter sw = new StringWriter();
            DataContractSerializer serializer = new DataContractSerializer(obj.GetType());
            using (XmlTextWriter xw = new XmlTextWriter(sw))
            {
                //serializer.WriteObject(xw, obj);
                //
                // Insert namespace for C# types
                serializer.WriteStartObject(xw, obj);
                xw.WriteAttributeString("xmlns", "x", null, "http://www.w3.org/2001/XMLSchema");
                serializer.WriteObjectContent(xw, obj);
                serializer.WriteEndObject(xw);
            }
            StringBuilder buffer = sw.GetStringBuilder();
            return buffer.ToString();
        }
