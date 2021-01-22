    public XDocument XDocument { get; set; }
        private async Task OpenResWFileAsync()
        {
            List<XElement> dataElements;
            var reswFile = await StorageHelper.PickSingleFileAsync(".resw");
            if (reswFile == null) return;
            using (Stream fileStream = await reswFile.OpenStreamForReadAsync())
            {
                this.XDocument = XDocument.Load(fileStream);
                dataElements = this.XDocument.Root.Elements("data").ToList();
                this.DataElements = dataElements;
            }
        }
        #region
        private List<string> GetValues()
        {
            if (this.XDocument == null) return new List<string>();
            return this.XDocument.Root.Elements("data").Select(e => e.Attribute("name").Value).ToList();
        }
        public void ChangeValue(string resourceKey, string newValue)
        {
            if (this.DataElements == null) return;
            var element = this.DataElements.Where(e => e.Name == resourceKey).Single();
            element.Value = newValue;
        }
        #endregion
