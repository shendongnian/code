    //https://stackoverflow.com/questions/49159697/deserializing-json-child-object-values-into-parent-object-using-jsonconvert-dese
    public class MeanVarianceTestResultsData
    {
        public int ResultsID { get; set; }
        public DateTime DateExecuted { get; set; }
        public string UserExecuted { get; set; }
        public string CorrectedMean { get; set; }
        public string CorrectedVariance { get; set; }
        public bool TestPassed { get; set; }
        public string TestResultImageFile { get; set; }
        public Stream TestResultImage { get; set; }
    }
    public static class MeanVarianceTestResultsDataExtensions
    {
        public static List<MeanVarianceTestResultsData> ReadResultListFrom(XmlReader reader, Func<MeanVarianceTestResultsData, Stream> openStream, Func<Stream, Stream> closeStream)
        {
            return reader.ReadSubtrees("TestResult").Select(r => ReadResultFrom(r, openStream, closeStream)).ToList();
        }
        public static MeanVarianceTestResultsData ReadResultFrom(XmlReader reader, Func<MeanVarianceTestResultsData, Stream> openStream, Func<Stream, Stream> closeStream)
        {
            if (reader == null || openStream == null)
                throw new ArgumentNullException();
            reader.MoveToContent();
            var result = new MeanVarianceTestResultsData();
            var isEmpty = reader.IsEmptyElement;
            // Read the root
            reader.Read();
            if (isEmpty)
                return result;
            while (!reader.EOF)
            {
                if (reader.NodeType == XmlNodeType.EndElement)
                {
                    reader.Read();
                    break;
                }
                else if (reader.NodeType != XmlNodeType.Element)
                    // Comment, text, CDATA, etc.
                    reader.Skip();
                else if (reader.Name == "ResultsID")
                    result.ResultsID = reader.ReadElementContentAsInt();
                else if (reader.Name == "DateExecuted")
                    result.DateExecuted = reader.ReadElementContentAsDateTime();
                else if (reader.Name == "UserExecuted")
                    result.UserExecuted = reader.ReadElementContentAsString();
                else if (reader.Name == "CorrectedMean")
                    result.CorrectedMean = reader.ReadElementContentAsString();
                else if (reader.Name == "TestPassed")
                    result.TestPassed = reader.ReadElementContentAsBoolean();
                else if (reader.Name == "TestResultImage")
                    result.TestResultImage = reader.ReadElementContentAsStream(() => openStream(result), closeStream);
                else
                    reader.Skip();
            }
            return result;
        }
    }
    public static class XmlReaderExtensions
    {
        public static Stream ReadElementContentAsStream(this XmlReader reader, Func<Stream> openStream, Func<Stream, Stream> closeStream)
        {
            if (reader == null || openStream == null)
                throw new ArgumentNullException();
            Stream stream = null;
            try
            {
                stream = openStream();
                byte[] buffer = new byte[4096];
                int readBytes = 0;
                while ((readBytes = reader.ReadElementContentAsBase64(buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, readBytes);
                }
            }
            finally
            {
                if (closeStream != null && stream != null)
                    stream = closeStream(stream);
            }
            return stream;
        }
        public static IEnumerable<XmlReader> ReadSubtrees(this XmlReader reader, string name)
        {
            while (reader.ReadToFollowing(name))
            {
                using (var subReader = reader.ReadSubtree())
                    yield return subReader;
            }
        }
    }
