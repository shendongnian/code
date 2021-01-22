    public string _sourceSubFolderName;
        [DefaultValueAttribute("")]
        [XmlElement("SourceSubFolderName")]
        public string SourceSubFolderName
        {
            get { return string.IsNullOrEmpty(_sourceSubFolderName) ? 
                   string.Empty : _sourceSubFolderName; }
            set { _sourceSubFolderName = value; }
        }
