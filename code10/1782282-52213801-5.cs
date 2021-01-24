    class AcadDocumentAdapter : IDocumentAdapter
    {
        public AcadDocumentAdapter(AutoCAD.AcadDocument document)
        {
            Document = document;
        }
        private AutoCAD.AcadDocument Document
        {
            get;
        }
        public bool Member1
        {
            get => Document.Member1;
            set => Document.Member1 = value;
        }
        public int Member2
        {
            get => Document.Member2;
            set => Document.Member2 = value;
        }
        public string Member3
        {
            get => Document.Member3;
            set => Document.Member3 = value;
        }
    }
    class AxDbDocumentAdapter : IDocumentAdapter
    {
        public AxDbDocumentAdapter(AXDBLib.AxDbDocument document)
        {
            Document = document;
        }
        private AXDBLib.AxDbDocument Document
        {
            get;
        }
        public bool Member1
        {
            get => Document.Member1;
            set => Document.Member1 = value;
        }
        public int Member2
        {
            get => Document.Member2;
            set => Document.Member2 = value;
        }
        public string Member3
        {
            get => Document.Member3;
            set => Document.Member3 = value;
        }
    }
