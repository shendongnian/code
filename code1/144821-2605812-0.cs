        static void Main(string[] args)
        {
            const int iterations = 20000;
            const string xml = @"<foo><bar><baz a='b' c='d'/><foo><bar><baz a='b' c='d'/></bar><bar/></foo><foo><bar><baz a='b' c='d'/></bar><bar/></foo><foo><bar><baz a='b' c='d'/></bar><bar/></foo><foo><bar><baz a='b' c='d'/></bar><bar/></foo><foo><bar><baz a='b' c='d'/></bar><bar/></foo><foo><bar><baz a='b' c='d'/></bar><bar/></foo><foo><bar><baz a='b' c='d'/></bar><bar/></foo><foo><bar><baz a='b' c='d'/></bar><bar/></foo><foo><bar><baz a='b' c='d'/></bar><bar/></foo></bar><bar/></foo>";
            Stopwatch st = new Stopwatch();
            st.Start();
            for (int i=0; i<iterations; i++)
            {
                using (StringReader sr = new StringReader(xml))
                using (XmlReader xr = XmlReader.Create(sr))
                {
                    while (xr.Read())
                    {
                    }
                }
            }
            st.Stop();
            Console.WriteLine(String.Format("XmlReader: {0} ms.", st.ElapsedMilliseconds));
            st.Reset();
            st.Start();
            for (int i=0; i<iterations; i++)
            {
                XElement.Parse(xml);
            }
            st.Stop();
            Console.WriteLine(String.Format("XElement: {0} ms.", st.ElapsedMilliseconds));
            st.Reset();
            st.Start();
            for (int i = 0; i < iterations; i++)
            {
                XmlDocument d= new XmlDocument();
                d.LoadXml(xml);
            }
            st.Stop();
            Console.WriteLine(String.Format("XmlDocument: {0} ms.", st.ElapsedMilliseconds));
            st.Reset();
            st.Start();
            for (int i = 0; i < iterations; i++)
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XPathDocument d = new XPathDocument(new StringReader(xml));                    
                }
            }
            st.Stop();
            Console.WriteLine(String.Format("XPathDocument: {0} ms.", st.ElapsedMilliseconds));
            Console.ReadKey();
        }
