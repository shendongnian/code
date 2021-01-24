    public static partial class JsonExtensions
    {
        // Adapted from the answer to
        // https://stackoverflow.com/questions/44787652/serialize-as-ndjson-using-json-net
        // by dbc https://stackoverflow.com/users/3744182/dbc
        public static void ToNewlineDelimitedJson<T>(Stream stream, IEnumerable<T> items)
        {
            var textWriter = new StreamWriter(stream);
            ToNewlineDelimitedJson(textWriter, items);
            textWriter.Flush(); // Let the caller dispose the stream
        }
        public static void ToNewlineDelimitedJson<T>(TextWriter textWriter, IEnumerable<T> items)
        {
            var serializer = JsonSerializer.CreateDefault();
            foreach (var item in items)
            {
                // Formatting.None is the default; I set it here for clarity.
                using (var writer = new JsonTextWriter(textWriter) { Formatting = Formatting.None, CloseOutput = false })
                {
                    serializer.Serialize(writer, item);
                }
                // http://specs.okfnlabs.org/ndjson/
                // Each JSON text MUST conform to the [RFC7159] standard and MUST be written to the stream followed by the newline character \n (0x0A). 
                // The newline charater MAY be preceeded by a carriage return \r (0x0D). The JSON texts MUST NOT contain newlines or carriage returns.
                textWriter.Write("\n");
            }
        }
        // Adapted from the answer to 
        // https://stackoverflow.com/questions/29729063/line-delimited-json-serializing-and-de-serializing
        // by Yuval Itzchakov https://stackoverflow.com/users/1870803/yuval-itzchakov
        public static IEnumerable<TBase> FromNewlineDelimitedJson<TBase, THeader, TRow>(TextReader reader)
            where THeader : TBase
            where TRow : TBase
        {
            bool first = true;
            using (var jsonReader = new JsonTextReader(reader) { CloseInput = false, SupportMultipleContent = true })
            {
                var serializer = JsonSerializer.CreateDefault();
                while (jsonReader.Read())
                {
                    if (jsonReader.TokenType == JsonToken.Comment)
                        continue;
                    if (first)
                    {
                        yield return serializer.Deserialize<THeader>(jsonReader);
						first = false;
                    }
                    else
                    {
                        yield return serializer.Deserialize<TRow>(jsonReader);
                    }
                }
            }
        }
    }
