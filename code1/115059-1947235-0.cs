    class DocumentDataSet : DataSet
    {
        public new string GetXml()
        {
            return base.GetXml().Replace("DocumentDataSet ", "Document");
        }
    }
