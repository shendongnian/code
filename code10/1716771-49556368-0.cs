    public interface IDocumentLoader<T> where T : class {
        T Load(string path);
    }
    public interface IXDocumentLoader : IDocumentLoader<XDocument> { }
    public class XDocumentLoader : IXDocumentLoader {
        public XDocument Load(string path) {
            return XDocument.Load(path);
        }
    }
    public interface IDocumentValidator<T> where T : class {
        void Validate(T document);
    }
    public interface IXDocumentValidator : IDocumentValidator<XDocument> { }
    public class XDocumentValidator : IXDocumentValidator {
        public void Validate(XDocument document) {
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("", XmlReader.Create(new StringReader("XsdFile")));
            document.Validate(schema, null);
        }
    }
    public class Subject {
        private IXDocumentLoader loader;
        private IXDocumentValidator validator;
        public Subject(IXDocumentLoader loader, IXDocumentValidator validator) {
            this.loader = loader;
            this.validator = validator;
        }
        public void Foo(string path) {
            try {
                XDocument document = loader.Load(path);
                validator.Validate(document);
                //Some logic
            } catch (Exception ex) {
                //Some logic
            }
        }
    }
    
