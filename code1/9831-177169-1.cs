        private static XmlSerializer GetOverridedSerializer()
        {
            // set overrides for TestObject element
            XmlAttributes attrsTestObject = new XmlAttributes();
            XmlRootAttribute rootTestObject = new XmlRootAttribute("SomethingElse");
            attrsTestObject.XmlRoot = rootTestObject;
           // create overrider
           XmlAttributeOverrides xOver = new XmlAttributeOverrides();
           xOver.Add(typeof(localhost.TestObject), attrsTestObject);
           XmlSerializer xSer = new XmlSerializer(typeof(localhost.TestObject), xOver);
           return xSer;
        }
