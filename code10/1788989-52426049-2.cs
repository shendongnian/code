    public class TestsXmlWrapper
    {
        private XmlDocument _xml;
        public TestsXmlWrapper(XmlDocument xml)
        {
            _xml = xml;
        }
        public IEnumerable<Site> Sites
        {
            get
            {
                foreach (XmlElement site in _xml.SelectNodes("SITES/SITE"))
                {
                    yield return new Site(site);
                }
            }
        }
    }
    public class Site
    {
        private XmlElement _site;
        public Site(XmlElement site)
        {
            _site = site;
        }
        public String ErrorCount => _site.SelectSingleNode("ERROR_COUNTER")?.InnerText;
        public String LoginUrl => _site.SelectSingleNode("LOGINFO/URL")?.InnerText;
        public String Username => _site.SelectSingleNode("LOGINFO/LOGIN")?.InnerText;
        public String Password => _site.SelectSingleNode("LOGINFO/PASSWORD")?.InnerText;
        public IEnumerable<Test> Test
        {
            get
            {
                foreach (XmlElement test in _site.SelectNodes("TESTS/TEST"))
                {
                    yield return new Test(test);
                }
            }
        }
    }
    public class Test
    {
        private XmlElement _test;
        public Test(XmlElement test)
        {
            _test = test;
        }
        public String Url => _test.SelectSingleNode("URL")?.InnerText;
    }
    ...the same for email
