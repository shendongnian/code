        void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(this);
            if (converter != null)
            {
                if (converter.CanConvertTo(typeof(string)))
                    writer.WriteString(converter.ConvertTo(this, typeof(string)) as string);
                else
                    throw new SerializationException(string.Format("The TypeConverter for type \"{0}\" cannot convert to string.", this.GetType().FullName));
            }
            else
                throw new SerializationException(string.Format("Unable to find a TypeConverter for type \"{0}\".", this.GetType().FullName));
        }
