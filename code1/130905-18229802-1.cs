    public enum eFileType
    {
        Invalid = -1,
        TextDocument = 0,
        RichTextDocument,
        WordDocument
    }
    public interface IRead
    {
        string Read(string file);
    }
    public static class FileManager
    {
        public static eFileType GetFileType(string extension)
        {
            var type = eFileType.Invalid;
            switch (extension)
            {
                case ".txt": type = eFileType.TextDocument;
                    break;
                case ".rtf": type = eFileType.RichTextDocument;
                    break;
                case ".docx": type = eFileType.WordDocument;
                    break;
            }
            return type;
        }
    }
    
    public class TextDocument : IRead
    {
        public string Read(string file)
        {
            try
            {
                var reader = new StreamReader(file);
                var content = reader.ReadToEnd();
                reader.Close();
                return content;
            }
            catch
            {
                return null;
            }
        }
    }
    public class RichTextDocument : IRead
    {
        public string Read(string file)
        {
            try
            {
                var wordApp = new Application();
                object path = file;
                object nullobj = System.Reflection.Missing.Value;
                var doc = wordApp.Documents.Open(ref path,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj);
                var result = wordApp.ActiveDocument.Content.Text;
                var doc_close = (_Document)doc;
                doc_close.Close();
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
    public class WordDocument : IRead
    {
        public string Read(string file)
        {
            try
            {
                var wordApp = new Application();
                object path = file;
                object nullobj = System.Reflection.Missing.Value;
                var doc = wordApp.Documents.Open(ref path,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj,
                                                      ref nullobj);
                var result = wordApp.ActiveDocument.Content.Text;
                var doc_close = (_Document)doc;
                doc_close.Close();
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
    public class Factory
    {
        public IRead Get(eFileType type)
        {
            IRead read = null;
            switch (type)
            {
                case eFileType.RichTextDocument: read = new RichTextDocument();
                    break;
                case eFileType.WordDocument: read = new WordDocument();
                    break;
                case eFileType.TextDocument: read = new TextDocument();
                    break;
            }
            return read;
        }
    }
    public class ResumeReader
    {
        IRead _read;
        public ResumeReader(IRead read)
        {
            if (read == null) throw new InvalidDataException("read cannot be null");
            _read = read;
        }
        public string Read(string file)
        {
            return _read.Read(file);
        }
    }    
