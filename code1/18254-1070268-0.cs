        private class NullSubsetXmlTextWriter : XmlTextWriter
        {
            public NullSubsetXmlTextWriter(String inputFileName, Encoding encoding)
                : base(inputFileName, encoding)
            {
            }
            public override void WriteDocType(string name, string pubid, string sysid, string subset)
            {
                if (subset == String.Empty)
                {
                    subset = null;
                }
                base.WriteDocType(name, pubid, sysid, subset);
            }
        }
