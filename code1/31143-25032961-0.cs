        [TestMethod]
        public void TestMethod()
        {
            A a = new A();
            a.field1 = "test";
            string xml = Serialize(a);
            xml = xml.Replace("A", "B");
            B b = Deserialize(xml);
            Assert.AreEqual("test", b.field1);
        }
        public string Serialize(A a)
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                XmlSerializer serializer = new XmlSerializer(typeof(A));
                serializer.Serialize(memoryStream, a);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }
        public static B Deserialize(string xml)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(xml);
                XmlSerializer serializer = new XmlSerializer(typeof(B));
                return ((B)(serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
