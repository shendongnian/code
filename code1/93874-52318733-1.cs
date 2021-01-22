    using NUnit.Framework;
    using System.Linq;
    using System.Xml.Linq;
    public class XMLHashUtilsTest
    {
        /// <summary>
        /// Outputs XML: <root><child attribute="value" /></root>
        /// where <child /> node repeats according to childCount
        /// </summary>
        XElement CreateXML(int childCount)
        {
            return new XElement("root", Enumerable.Repeat(new XElement("child", new XAttribute("attribute", "value")), childCount));
        }
        [Test]
        public void HashIsDeterministic([Values(0,1,10)] int childCount)
        {
            var xml = CreateXML(childCount);
            Assert.AreEqual(XMLHashUtils.Hash(xml), XMLHashUtils.Hash(xml));
        }
        [Test]
        public void HashChanges_WhenChildrenAreDifferent([Values(0,1,10)] int childCount)
        {
            var xml1 = CreateXML(childCount);
            var xml2 = CreateXML(childCount + 1);
            Assert.AreNotEqual(XMLHashUtils.Hash(xml1), XMLHashUtils.Hash(xml2));
        }
        [Test]
        public void HashChanges_WhenRootNameIsDifferent([Values("A","B","C")]string nameSuffix)
        {
            var xml1 = CreateXML(1);
            var xml2 = CreateXML(1);
            xml2.Name = xml2.Name + nameSuffix;
            Assert.AreNotEqual(XMLHashUtils.Hash(xml1), XMLHashUtils.Hash(xml2));
        }
        [Test]
        public void HashChanges_WhenRootAttributesAreDifferent([Values("A","B","C")]string attributeName)
        {
            var xml1 = CreateXML(1);
            var xml2 = CreateXML(1);
            xml2.Add(new XAttribute(attributeName, "value"));
            Assert.AreNotEqual(XMLHashUtils.Hash(xml1), XMLHashUtils.Hash(xml2));
        }
    }
