    public class JayRockMarshaller : IMarshaller
    {
        public ICollection Read(string text)
        {
            return (ICollection)new ImportContext().Import(new JsonTextReader(new StringReader(text)));
        }
        public string Write(ICollection objectToMarshal)
        {
            var writer = new StringWriter();
            new ExportContext().Export(objectToMarshal, new JsonTextWriter(writer));
            return writer.ToString();
        }
    }
